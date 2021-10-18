namespace _02_DAO.Model
{
    class Producto
    {
        // Data Transfer Object
        private string codigo;
        private string desc;
        private decimal precio;
        private int cantidad;

        //Getters y Setters (Propiedades de la clase)
        public string Codigo { get => codigo; set => codigo = value; }
        public string Desc { get => desc; set => desc = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
