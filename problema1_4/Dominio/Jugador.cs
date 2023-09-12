using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_4.Dominio
{
    internal class Jugador
    {
        public Persona Persona { get; set; }

        public int NroCamiseta { get; set; }

        public Posicion Posicion { get; set; }

        public Jugador(Persona persona,int nroCamiseta,Posicion posicion) { 
            Persona = persona;
            NroCamiseta = nroCamiseta;
            Posicion = posicion;
        }

    }
}
