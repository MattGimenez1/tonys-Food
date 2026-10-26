using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioStockVenta
    {
        // Descuenta del stock los insumos que gastó una venta ya registrada.
        // Nunca lanza error: si algo falla, la venta queda igual y el motivo se ve en la ventana Salida de Visual Studio.
        public void descontarVenta(int idVenta, int idUsuario, List<DetalleVenta> detalles)
        {
            try
            {
                DaoStockVenta dao = new DaoStockVenta();
                NegocioMovimientosStock negMov = new NegocioMovimientosStock();
                Dictionary<int, int> totalesPorInsumo = new Dictionary<int, int>();

                foreach (DetalleVenta det in detalles)
                {
                    List<ExtraElegido> extras = det.getExtras_Sel();
                    DataTable vinculos = dao.getVinculosDeLinea(det.getId_Producto_D(), det.getId_Tamano_Sel(), extras);

                    foreach (DataRow fila in vinculos.Rows)
                    {
                        int idInsumo = Convert.ToInt32(fila["IdInsumo"]);
                        int cantidadVinculo = Convert.ToInt32(fila["Cantidad"]);

                        // Producto y tamaño cuentan 1 vez por unidad vendida; un extra cuenta tantas veces como se pidió
                        int veces = 1;
                        if (fila["IdExtra"] != DBNull.Value)
                        {
                            int idExtra = Convert.ToInt32(fila["IdExtra"]);
                            veces = 0;
                            foreach (ExtraElegido ex in extras)
                                if (ex.getId_Extra() == idExtra) veces += ex.getCantidad();
                        }

                        int total = cantidadVinculo * veces * det.getCantidad_D();
                        if (total <= 0) continue;

                        if (totalesPorInsumo.ContainsKey(idInsumo)) totalesPorInsumo[idInsumo] += total;
                        else totalesPorInsumo[idInsumo] = total;
                    }
                }

                foreach (KeyValuePair<int, int> par in totalesPorInsumo)
                {
                    try
                    {
                        negMov.descontarInsumo(par.Key, par.Value, idVenta, idUsuario);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("No se pudo descontar el insumo " + par.Key + ": " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("No se pudo descontar el stock de la venta " + idVenta + ": " + ex.Message);
            }
        }
    }
}