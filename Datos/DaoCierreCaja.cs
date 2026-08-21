using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoCierreCaja
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTotalesParaCierre()
        {
            return ds.ObtenerTabla("TotalesCierre",
                "DECLARE @UltimoCierre DATETIME; " +
                "SELECT @UltimoCierre = MAX(FechaHora_CC) FROM CierresCaja; " +
                "IF @UltimoCierre IS NULL SET @UltimoCierre = '2000-01-01'; " +
                "SELECT " +
                "ISNULL(SUM(CASE WHEN FormaPago_V = 'Efectivo' THEN Total_V ELSE 0 END), 0) AS TotalEfectivo, " +
                "ISNULL(SUM(CASE WHEN FormaPago_V = 'Transferencia' THEN Total_V ELSE 0 END), 0) AS TotalTransferencia, " +
                "ISNULL(SUM(CASE WHEN FormaPago_V = 'QR/Tarjeta' THEN Total_V ELSE 0 END), 0) AS TotalQR, " +
                "ISNULL(SUM(Total_V), 0) AS TotalGeneral " +
                "FROM Ventas WHERE Fecha_V > @UltimoCierre");
        }

        public bool registrarCierre(int idUsuario, decimal totalEfectivo, decimal totalTransferencia, decimal totalQR, decimal totalGeneral)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Usuario_CC", idUsuario);
                comando.Parameters.AddWithValue("@TotalEfectivo_CC", totalEfectivo);
                comando.Parameters.AddWithValue("@TotalTransferencia_CC", totalTransferencia);
                comando.Parameters.AddWithValue("@TotalQR_CC", totalQR);
                comando.Parameters.AddWithValue("@TotalGeneral_CC", totalGeneral);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spRegistrarCierre");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }
    }
}