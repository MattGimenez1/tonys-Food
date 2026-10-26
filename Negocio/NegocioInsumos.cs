using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocio
{
    public class NegocioInsumos
    {
        public bool agregarInsumo(string nombre, int stockInicial, int stockMinimo, int idUsuario)
        {
            int cantFilas = 0;

            if (string.IsNullOrWhiteSpace(nombre)) return false;
            if (stockInicial < 0 || stockMinimo < 0) return false;

            DaoInsumos dao = new DaoInsumos();
            Insumo ins = new Insumo();
            ins.setNombre_Ins(nombre.Trim());
            ins.setStock_Ins(stockInicial);
            ins.setStockMinimo_Ins(stockMinimo);
            ins.setActivo_Ins(true);

            if (dao.ExisteInsumoxNombre(ins) == false)
            {
                // El procedimiento hace 2 inserts (insumo + movimiento 'Alta'), por eso >= 1
                cantFilas = dao.agregarInsumo(ins, idUsuario);
            }

            return cantFilas >= 1;
        }

        public bool modificarInsumo(int idInsumo, string nombre, int stockMinimo)
        {
            int cantFilas = 0;

            if (string.IsNullOrWhiteSpace(nombre)) return false;
            if (stockMinimo < 0) return false;

            DaoInsumos dao = new DaoInsumos();
            Insumo ins = new Insumo();
            ins.setId_Insumo_Ins(idInsumo);
            ins.setNombre_Ins(nombre.Trim());
            ins.setStockMinimo_Ins(stockMinimo);

            // Que no le ponga el nombre de OTRO insumo que ya existe
            DataTable todos = dao.getTablaInsumosTodos();
            foreach (DataRow fila in todos.Rows)
            {
                if (Convert.ToInt32(fila["Id"]) != idInsumo &&
                    string.Equals(fila["Nombre"].ToString(), ins.getNombre_Ins(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            if (dao.ExisteInsumoxId(ins) == true)
            {
                cantFilas = dao.modificarInsumo(ins);
            }

            return cantFilas == 1;
        }

        public bool eliminarInsumo(int idInsumo)
        {
            int cantFilas = 0;

            DaoInsumos dao = new DaoInsumos();
            Insumo ins = new Insumo();
            ins.setId_Insumo_Ins(idInsumo);

            if (dao.ExisteInsumoxId(ins) == true)
            {
                cantFilas = dao.eliminarInsumo(ins);
            }

            return cantFilas == 1;
        }

        public bool activarInsumo(int idInsumo)
        {
            DaoInsumos dao = new DaoInsumos();
            return dao.activarInsumo(idInsumo);
        }

        public DataTable getTabla()
        {
            DaoInsumos dao = new DaoInsumos();
            return dao.getTablaInsumos();
        }

        public DataTable getTablaTodos()
        {
            DaoInsumos dao = new DaoInsumos();
            return dao.getTablaInsumosTodos();
        }
    }
}