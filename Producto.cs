using System;

namespace TiendaEnLinea.Modelos
{
    public class Producto
    {
        // Propiedades privadas
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private int _cantidadStock;

        // Propiedades públicas con validaciones
        public Guid Id { get; private set; }

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

        // Resto del código de la clase Producto...
    }
}

// Agrega los comandos de Git al final
git remote add origin https://github.com/CindyPaola15/Grupo-D-POO-.git
git branch -M main
git push -u origin main
