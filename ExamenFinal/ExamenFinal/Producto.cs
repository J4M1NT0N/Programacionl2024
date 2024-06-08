public class Producto
{
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }

    public override string ToString()
    {
        return $"Usuario: {Usuario}, Nombre: {Nombre}, Precio: {Precio}, Existencia: {Existencia}";
    }
}