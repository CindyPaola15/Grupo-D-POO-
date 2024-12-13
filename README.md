using System;
using System.Collections.Generic;

namespace TiendaEnLinea
{
    // Clase Producto
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }

    // Clase Cliente
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public List<Producto> HistorialDeCompras { get; set; } = new List<Producto>();
        public List<Producto> Carrito { get; set; } = new List<Producto>();

        public Cliente(string nombre, string direccion, string correo)
        {
            Nombre = nombre;
            Direccion = direccion;
            CorreoElectronico = correo;
        }

        // Método para ver el carrito
        public void VerCarrito()
        {
            Console.WriteLine("Carrito de compras de " + Nombre);
            if (Carrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var producto in Carrito)
                {
                    Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
                }
            }
        }

        // Método para realizar una compra
        public void RealizarCompra()
        {
            if (Carrito.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito para comprar.");
                return;
            }

            decimal total = 0;
            foreach (var producto in Carrito)
            {
                total += producto.Precio;
            }

            Console.WriteLine($"Total a pagar: ${total}");
            Console.WriteLine("Compra realizada con éxito!");

            // Agregar los productos al historial de compras
            foreach (var producto in Carrito)
            {
                HistorialDeCompras.Add(producto);
            }

            // Limpiar el carrito
            Carrito.Clear();
        }
    }

    // Clase Tienda
    public class Tienda
    {
        public List<Producto> Inventario { get; set; } = new List<Producto>();

        public Tienda()
        {
            // Agregar algunos productos al inventario
            Inventario.Add(new Producto("Camiseta", 15.99m));
            Inventario.Add(new Producto("Pantalón", 30.99m));
            Inventario.Add(new Producto("Zapatos", 50.00m));
        }

        // Método para mostrar el inventario
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de la tienda:");
            for (int i = 0; i < Inventario.Count; i++)
            {
                var producto = Inventario[i];
                Console.WriteLine($"{i + 1}. {producto.Nombre} - ${producto.Precio}");
            }
        }

        // Método para agregar productos al carrito del cliente
        public void AgregarAlCarrito(Cliente cliente, int indiceProducto)
        {
            if (indiceProducto >= 1 && indiceProducto <= Inventario.Count)
            {
                var producto = Inventario[indiceProducto - 1];
                cliente.Carrito.Add(producto);
                Console.WriteLine($"{producto.Nombre} ha sido agregado al carrito.");
            }
            else
            {
                Console.WriteLine("Producto no válido.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una tienda y un cliente
            Tienda tienda = new Tienda();
            Cliente cliente = new Cliente("Juan Pérez", "Calle Ficticia 123", "juan@email.com");

            bool seguir = true;
            while (seguir)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a la Tienda en Línea");
                Console.WriteLine($"Cliente: {cliente.Nombre}");
                Console.WriteLine("1. Ver inventario");
                Console.WriteLine("2. Ver carrito");
                Console.WriteLine("3. Realizar compra");
                Console.WriteLine("4. Salir");
                Console.Write("Elija una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        tienda.MostrarInventario();
                        Console.Write("Seleccione un producto para agregar al carrito (número): ");
                        if (int.TryParse(Console.ReadLine(), out int opcionProducto))
                        {
                            tienda.AgregarAlCarrito(cliente, opcionProducto);
                        }
                        break;

                    case "2":
                        cliente.VerCarrito();
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "3":
                        cliente.RealizarCompra();
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "4":
                        seguir = false;
                        Console.WriteLine("¡Gracias por visitar la tienda!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
