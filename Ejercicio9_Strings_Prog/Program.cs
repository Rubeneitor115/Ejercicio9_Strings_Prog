/***
 * Rubén Bernal Ramos
 * CSI1
 */

using System.Linq;

namespace Ejercicio9_Strings_Prog
{
    /// <summary>
    /// Clase principal de la aplicación
    /// rbr - 070324
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método principal de la aplicación
        /// rbr - 070324
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Paso 1: Solicitar al usuario ingresar una frase y reemplazar vocales
            Console.WriteLine("Ingresa una frase:");
            string frase = Console.ReadLine();
            string fraseSinVocales = ReemplazarVocales(frase);

            // Paso 2: Dividir la frase en "trozos" por el espacio
            string[] trozosFrase = frase.Split(' ');

            // Paso 3: Escribir la lista de trozos en un archivo
            string nombreArchivo = "C:\\Users\\Ruben\\Desktop\\GRADO\\C#\\TERCERA EVALUACION\\Ejercicio9_Strings_Prog\\Ejercicio9_Strings_Prog\\Ficheros" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            EscribirArchivo(nombreArchivo, trozosFrase);

            // Paso 4: Leer las dos últimas líneas del archivo
            string[] ultimasLineas = LeerUltimasLineas(nombreArchivo, 2);

            // Paso 5: Mostrar las dos últimas líneas en una sola línea
            Console.WriteLine("Las dos últimas líneas del archivo son:");
            foreach (string linea in ultimasLineas)
            {
                Console.Write(linea + " ");
            }
            Console.WriteLine();

            // Paso 6: Preguntar al usuario cuántas vocales faltan
            Console.WriteLine("¿Cuántas vocales faltan?");
            int vocalesFaltan = int.Parse(Console.ReadLine());

            // Paso 7: Preguntar por las vocales faltantes
            Console.WriteLine("Ingresa las vocales faltantes (en minúscula):");
            string vocalesFaltantes = "";
            for (int i = 0; i < vocalesFaltan; i++)
            {
                Console.Write($"Vocal {i + 1}: ");
                vocalesFaltantes += Console.ReadLine();
            }

            // Paso 8: Mostrar la frase completa con las vocales dadas
            string fraseCompleta = ReemplazarVocalesFaltantes(fraseSinVocales, vocalesFaltantes);
            Console.WriteLine("La frase completa con las vocales dadas es:");
            Console.WriteLine(fraseCompleta);
        }

        static string ReemplazarVocales(string frase)
        {
            char[] vocales = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char vocal in vocales)
            {
                frase = frase.Replace(vocal, '*');
            }
            return frase;
        }

        static void EscribirArchivo(string nombreArchivo, string[] lineas)
        {
            using (StreamWriter sw = new StreamWriter(nombreArchivo))
            {
                foreach (string linea in lineas)
                {
                    sw.WriteLine(linea);
                }
            }
        }

        static string[] LeerUltimasLineas(string nombreArchivo, int numLineas)
        {
            List<string> ultimasLineas = new List<string>();
            using (StreamReader sr = new StreamReader(nombreArchivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    ultimasLineas.Add(linea);
                    if (ultimasLineas.Count > numLineas)
                    {
                        ultimasLineas.RemoveAt(0);
                    }
                }
            }
            return ultimasLineas.ToArray();
        }

        static string ReemplazarVocalesFaltantes(string fraseSinVocales, string vocalesFaltantes)
        {
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < vocalesFaltantes.Length; i++)
            {
                fraseSinVocales = fraseSinVocales.Replace('*', vocalesFaltantes[i]);
            }
            return fraseSinVocales;
        }
    }
}