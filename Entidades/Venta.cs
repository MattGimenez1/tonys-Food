using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        private int Id_Venta_V;
        private System.DateTime Fecha_V;
        private decimal Total_V;
        private int Id_Usuario_V;
        private string FormaPago_V;

        public Venta() { }

        public int getId_Venta_V() { return Id_Venta_V; }
        public void setId_Venta_V(int id) { Id_Venta_V = id; }

        public System.DateTime getFecha_V() { return Fecha_V; }
        public void setFecha_V(System.DateTime fecha) { Fecha_V = fecha; }

        public decimal getTotal_V() { return Total_V; }
        public void setTotal_V(decimal total) { Total_V = total; }

        public int getId_Usuario_V() { return Id_Usuario_V; }
        public void setId_Usuario_V(int id) { Id_Usuario_V = id; }

        public string getFormaPago_V() { return FormaPago_V; }
        public void setFormaPago_V(string formaPago) { FormaPago_V = formaPago; } 

    }
}