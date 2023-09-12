using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_4.Dominio
{
    internal class Persona
    {

        public int DniPersona { get; set; }
        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Persona(int dniPersona,string nombreCompleto,DateTime fechaNacimiento) { 
            DniPersona = dniPersona;
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }

    }
}
