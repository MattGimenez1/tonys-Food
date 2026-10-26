using System;

namespace Entidades
{
    public class MovimientoStock
    {
        private int Id_Movimiento_M;
        private int Id_Insumo_M;
        private DateTime Fecha_M;
        private int Id_Usuario_M;
        private string Tipo_M;        // Alta, Ingreso, Venta, Ajuste
        private int Cantidad_M;       // con signo: + entra, - sale
        private string Detalle_M;
        private int? Id_Venta_M;

        public MovimientoStock() { }

        public int getId_Movimiento_M() { return Id_Movimiento_M; }
        public void setId_Movimiento_M(int id) { Id_Movimiento_M = id; }

        public int getId_Insumo_M() { return Id_Insumo_M; }
        public void setId_Insumo_M(int id) { Id_Insumo_M = id; }

        public DateTime getFecha_M() { return Fecha_M; }
        public void setFecha_M(DateTime fecha) { Fecha_M = fecha; }

        public int getId_Usuario_M() { return Id_Usuario_M; }
        public void setId_Usuario_M(int id) { Id_Usuario_M = id; }

        public string getTipo_M() { return Tipo_M; }
        public void setTipo_M(string tipo) { Tipo_M = tipo; }

        public int getCantidad_M() { return Cantidad_M; }
        public void setCantidad_M(int cantidad) { Cantidad_M = cantidad; }

        public string getDetalle_M() { return Detalle_M; }
        public void setDetalle_M(string detalle) { Detalle_M = detalle; }

        public int? getId_Venta_M() { return Id_Venta_M; }
        public void setId_Venta_M(int? id) { Id_Venta_M = id; }
    }
}