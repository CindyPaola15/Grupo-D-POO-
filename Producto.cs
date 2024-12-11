<userStyle>Normal</userStyle>

namespace TiendaEnLinea.Modelos
{
    public class Producto
    {
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private int _cantidadStock;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del producto no puede estar vacío.");
                _nombre = value;
            }
        }

        public string Descripcion
        {
            get => _descripcion;
            set { _descripcion = value; }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio no puede ser negativo.");
                _precio = value;
            }
        }

        public int CantidadStock
        {
            get => _cantidadStock;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad en stock no puede ser negativa.");
                _cantidadStock = value;
            }
        }

        public void AgregarAlCarrito()
        {
            Console.WriteLine($"Se ha agregado {Nombre} al carrito de compras.");
        }
    }
}
