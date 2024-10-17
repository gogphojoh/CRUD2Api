namespace CRUD2Api.Models;

public class Usuarios
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? email { get; set; }
}

public class Productos
{
    public int id {get; set;}
    public string? nombre {get; set;}
    public int precio {get; set;}
}

public class Pedidos
{
    public int id {get; set;}
    public int usuarioId {get; set;}
    public string? productos {get; set;}
}