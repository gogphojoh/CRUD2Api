using Microsoft.EntityFrameworkCore;

namespace CRUD2Api.Models;

public class TiendaContext : DbContext
{
    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public DbSet<Usuarios>Usuario { get; set; } = null!;
    public DbSet<Productos>Producto{get; set;} = null!;
    public DbSet<Pedidos>Pedido{get; set;} = null!;
}