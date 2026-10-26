using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocio
{
    public class NegocioVinculos
    {
        // Hay que pasar UN solo origen (producto, tamaño o extra); los otros dos van en null
        public bool agregarVinculo(int idInsumo, int? idProducto, int? idTamano, int? idExtra, int cantidad)
        {
            int cantFilas = 0;

            if (cantidad <= 0) return false;

            int origenes = (idProducto.HasValue ? 1 : 0) + (idTamano.HasValue ? 1 : 0) + (idExtra.HasValue ? 1 : 0);
            if (origenes != 1) return false;

            DaoVinculos dao = new DaoVinculos();
            VinculoInsumo vin = new VinculoInsumo();
            vin.setId_Insumo_VI(idInsumo);
            vin.setId_Producto_VI(idProducto);
            vin.setId_Tamano_VI(idTamano);
            vin.setId_Extra_VI(idExtra);
            vin.setCantidad_VI(cantidad);

            if (dao.ExisteVinculoDuplicado(vin) == false)
            {
                cantFilas = dao.agregarVinculo(vin);
            }

            return cantFilas == 1;
        }

        public bool modificarVinculo(int idVinculo, int idInsumo, int cantidad)
        {
            int cantFilas = 0;

            if (cantidad <= 0) return false;

            DaoVinculos dao = new DaoVinculos();
            VinculoInsumo vin = new VinculoInsumo();
            vin.setId_Vinculo_VI(idVinculo);
            vin.setId_Insumo_VI(idInsumo);
            vin.setCantidad_VI(cantidad);

            if (dao.ExisteVinculoxId(vin) == true)
            {
                try
                {
                    cantFilas = dao.modificarVinculo(vin);
                }
                catch (Exception)
                {
                    // Por ejemplo: cambiarlo a un insumo que ya está vinculado a ese mismo origen
                    return false;
                }
            }

            return cantFilas == 1;
        }

        public bool eliminarVinculo(int idVinculo)
        {
            int cantFilas = 0;

            DaoVinculos dao = new DaoVinculos();
            VinculoInsumo vin = new VinculoInsumo();
            vin.setId_Vinculo_VI(idVinculo);

            if (dao.ExisteVinculoxId(vin) == true)
            {
                cantFilas = dao.eliminarVinculo(vin);
            }

            return cantFilas == 1;
        }

        public DataTable getTabla()
        {
            DaoVinculos dao = new DaoVinculos();
            return dao.getTablaVinculos();
        }

        public DataTable getTablaxProducto(int idProducto)
        {
            DaoVinculos dao = new DaoVinculos();
            return dao.getTablaVinculosxProducto(idProducto);
        }

        public DataTable getTablaxInsumo(int idInsumo)
        {
            DaoVinculos dao = new DaoVinculos();
            return dao.getTablaVinculosxInsumo(idInsumo);
        }
    }
}