namespace Entidades
{
    public class Insumo
    {
        private int Id_Insumo_Ins;
        private string Nombre_Ins;
        private int Stock_Ins;
        private int StockMinimo_Ins;
        private bool Activo_Ins;

        public Insumo() { }

        public int getId_Insumo_Ins() { return Id_Insumo_Ins; }
        public void setId_Insumo_Ins(int id) { Id_Insumo_Ins = id; }

        public string getNombre_Ins() { return Nombre_Ins; }
        public void setNombre_Ins(string nombre) { Nombre_Ins = nombre; }

        public int getStock_Ins() { return Stock_Ins; }
        public void setStock_Ins(int stock) { Stock_Ins = stock; }

        public int getStockMinimo_Ins() { return StockMinimo_Ins; }
        public void setStockMinimo_Ins(int minimo) { StockMinimo_Ins = minimo; }

        public bool getActivo_Ins() { return Activo_Ins; }
        public void setActivo_Ins(bool activo) { Activo_Ins = activo; }
    }
}