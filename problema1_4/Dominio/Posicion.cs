using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_4.Dominio
{
    internal class Posicion
    {
        public int CodPosicion { get; set; }
        public string NombrePosicion { get; set; }

        public Posicion(int codPosicion,string nombrePosicion)
        {
            CodPosicion = codPosicion;
            NombrePosicion = nombrePosicion;
        }

        public override string ToString()
        {
            return NombrePosicion;
        }

    }
}
