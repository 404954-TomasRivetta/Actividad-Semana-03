using Microsoft.Win32;
using problema1_1.Presentaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_1
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }

        //Para el problema seleccionado: 
        //    - Refactorizar alta utilizando transacciones.
        //    - Implementar baja lógica de la consulta general con al menos un filtro de búsqueda.
        //    - Desarrollar ventana modal para ver los detalles completos de un registro consultado.
        //    - Instalar complementos: RDLC y ReportViewer para trabajo con reportes desde Visual Studio.
    }
}
