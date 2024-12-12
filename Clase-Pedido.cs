using System;
using System.Collections.Generic;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; }
    public decimal Total { get; set; }
    public List<DetallePedido> Detalles { get; set; }
    public Cliente Cliente { get; set; }

    public Pedido(int id, DateTime fecha, string estado, decimal total, Cliente cliente)
    {
        Id = id;
        Fecha = fecha;
        Estado = estado;
        Total = total;
        Cliente = cliente;
        Detalles = new List<DetallePedido>();
    }

    public void AgregarDetalle(DetallePedido detalle)
    {
        Detalles.Add(detalle);
        Total += detalle.Precio * detalle.Cantidad;
    }

    public void CancelarPedido()
    {
        Estado = "Cancelado";
    }

    public void ConfirmarPedido()
    {
        Estado = "Confirmado";
    }

    public void MostrarDetalles()
    {
        Console.WriteLine("Detalles del pedido:");
        foreach (var detalle in Detalles)
        {
            Console.WriteLine($"Producto: {detalle.Producto.Nombre}, Cantidad: {detalle.Cantidad}, Precio: {detalle.Precio}");
        }
    }
}

public class DetallePedido
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public DetallePedido(Producto producto, int cantidad, decimal precio)
    {
        Producto = producto;
        Cantidad = cantidad;
        Precio = precio;
    }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }

    public Producto(int id, string nombre, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public Cliente(int id, string nombre, string apellido)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cliente = new Cliente(1, "Juan", "Pérez");
        var producto1 = new Producto(1, "Producto 1", 10.99m);
        var producto2 = new Producto(2, "Producto 2", 5.99m);

        var pedido = new Pedido(1, DateTime.Now, "Pendiente", 0, cliente);
        pedido.AgregarDetalle(new DetallePedido(producto1, 2, 10.99m));
        pedido.AgregarDetalle(new DetallePedido(producto2, 1, 5.99m));

        Console.WriteLine("Pedido:");
        Console.WriteLine($"Id: {pedido.Id}");
        Console.WriteLine($"Fecha: {pedido.Fecha}");
        Console.WriteLine($"Estado: {pedido.Estado}");
        Console.WriteLine($"Total: {pedido.Total}");
        Console.WriteLine($"Cliente: {pedido.Cliente.Nombre} {pedido.Cliente.Apellido}");

        pedido.MostrarDetalles();

        Console.WriteLine("¿Desea confirmar el pedido? (S/N)");
        var respuesta = Console.ReadLine();
        if (respuesta.ToUpper() == "S")
        {
            pedido.ConfirmarPedido();
            Console.WriteLine("Pedido confirmado.");
        }
        else
        {
            pedido.CancelarPedido();
            Console.WriteLine("Pedido cancelado.");
        }
    }
}