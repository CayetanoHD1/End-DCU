using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio
    {
        D_Datos date = new D_Datos();
        public void Insert(C_Entidades info)
        {
            date.Insertar(info);

        }
        public List<C_Entidades> listando(string buscar)
        {
            return date.ListarInformacion(buscar);
        }
        public void Eliminando(C_Entidades info)
        {
            date.Eliminar_Informacion(info);
        }
    }
}
