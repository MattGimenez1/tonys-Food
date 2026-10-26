namespace Entidades
{
    public class ExtraElegido
    {
        private int Id_Extra;
        private int Cantidad;

        public ExtraElegido() { }

        public ExtraElegido(int idExtra, int cantidad)
        {
            Id_Extra = idExtra;
            Cantidad = cantidad;
        }

        public int getId_Extra() { return Id_Extra; }
        public void setId_Extra(int id) { Id_Extra = id; }

        public int getCantidad() { return Cantidad; }
        public void setCantidad(int cantidad) { Cantidad = cantidad; }
    }
}