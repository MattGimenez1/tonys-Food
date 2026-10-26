namespace Entidades
{
    public class VinculoInsumo
    {
        private int Id_Vinculo_VI;
        private int Id_Insumo_VI;
        private int? Id_Producto_VI;   // solo uno de los tres origenes tiene valor,
        private int? Id_Tamano_VI;     // los otros dos quedan en null
        private int? Id_Extra_VI;
        private int Cantidad_VI;

        public VinculoInsumo() { }

        public int getId_Vinculo_VI() { return Id_Vinculo_VI; }
        public void setId_Vinculo_VI(int id) { Id_Vinculo_VI = id; }

        public int getId_Insumo_VI() { return Id_Insumo_VI; }
        public void setId_Insumo_VI(int id) { Id_Insumo_VI = id; }

        public int? getId_Producto_VI() { return Id_Producto_VI; }
        public void setId_Producto_VI(int? id) { Id_Producto_VI = id; }

        public int? getId_Tamano_VI() { return Id_Tamano_VI; }
        public void setId_Tamano_VI(int? id) { Id_Tamano_VI = id; }

        public int? getId_Extra_VI() { return Id_Extra_VI; }
        public void setId_Extra_VI(int? id) { Id_Extra_VI = id; }

        public int getCantidad_VI() { return Cantidad_VI; }
        public void setCantidad_VI(int cantidad) { Cantidad_VI = cantidad; }
    }
}