using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVenta
    {
        private int Id_Detalle_D;
        private int Id_Venta_D;
        private int Id_Producto_D;
        private int Cantidad_D;
        private decimal PrecioUnitario_D;
        private decimal Subtotal_D;

        // Solo en memoria (no se guardan en DetalleVentas): sirven para calcular el descuento de stock
        private int? Id_Tamano_Sel;
        private List<ExtraElegido> Extras_Sel = new List<ExtraElegido>();

        public DetalleVenta() { }

        public int getId_Detalle_D() { return Id_Detalle_D; }
        public void setId_Detalle_D(int id) { Id_Detalle_D = id; }

        public int getId_Venta_D() { return Id_Venta_D; }
        public void setId_Venta_D(int id) { Id_Venta_D = id; }

        public int getId_Producto_D() { return Id_Producto_D; }
        public void setId_Producto_D(int id) { Id_Producto_D = id; }

        public int getCantidad_D() { return Cantidad_D; }
        public void setCantidad_D(int cantidad) { Cantidad_D = cantidad; }

        public decimal getPrecioUnitario_D() { return PrecioUnitario_D; }
        public void setPrecioUnitario_D(decimal precio) { PrecioUnitario_D = precio; }

        public decimal getSubtotal_D() { return Subtotal_D; }
        public void setSubtotal_D(decimal subtotal) { Subtotal_D = subtotal; }

        public int? getId_Tamano_Sel() { return Id_Tamano_Sel; }
        public void setId_Tamano_Sel(int? id) { Id_Tamano_Sel = id; }

        public List<ExtraElegido> getExtras_Sel() { return Extras_Sel; }
        public void setExtras_Sel(List<ExtraElegido> extras)
        {
            Extras_Sel = extras ?? new List<ExtraElegido>();
        }
    }
}