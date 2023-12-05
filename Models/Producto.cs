namespace apiProductos.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public DateTime Fecha { get; set; }

        public bool Activo { get; set; }


        public Producto(int Id, string Nombre, string Descripcion, decimal Precio, DateTime Fecha, bool Activo)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
            this.Fecha = Fecha;
            this.Activo = Activo;
        }

    }
}