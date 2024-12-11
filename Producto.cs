namespace TiendaEnLinea
{
    public class Producto
    {
        // Propiedades privadas
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private int _cantidadStock;

        // Propiedad pública para el nombre
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

        // Propiedad pública para la descripción
        public string Descripcion
        {
            get => _descripcion;
            set { _descripcion = value; }
        }

        // Propiedad pública para el precio
        public decimal Precio
        {
            get => _precio;
            set { _precio = value; }
        }

        // Propiedad pública para la cantidad en stock
        public int CantidadStock
        {
            get => _cantidadStock;
            set { _cantidadStock = value; }
        }

        // Método público para agregar el producto al carrito
        public void AgregarAlCarrito()
        {
            // Lógica para agregar el producto al carrito de compras
            Console.WriteLine($"Se ha agregado {Nombre} al carrito de compras.");
        }
    }
}

git remote add origin https://github.com/CindyPaola15/Grupo-D-POO-.git
git branch -M main
git push -u origin main
