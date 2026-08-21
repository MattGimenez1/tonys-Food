using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioCierreCaja
    {
        DaoCierreCaja dao = new DaoCierreCaja();

        public DataTable getTotalesParaCierre() => dao.getTotalesParaCierre();

        public bool registrarCierre(int idUsuario, decimal totalEfectivo, decimal totalTransferencia, decimal totalQR, decimal totalGeneral)
        {
            return dao.registrarCierre(idUsuario, totalEfectivo, totalTransferencia, totalQR, totalGeneral);
        }
    }
}