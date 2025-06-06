﻿using System.Diagnostics;
using System.Drawing;


namespace _01DatosSecuencial
{
    class Program
    {
        /// <summary>
        /// Versión secuencial de un programa que recupera todos los jpg de un directorio,
        /// los rota 180 grados y los almacena en un nuevo directorio.
        /// </summary>
        static void Main()
        {

            string[] ficheros = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string nuevaCarpeta = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(nuevaCarpeta);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string fichero in ficheros)
            {
                string nombreFichero = Path.GetFileName(fichero);
                using (Bitmap bitmap = new Bitmap(fichero))
                {

                    Console.WriteLine($"Procesando el fichero \"{nombreFichero}\" con el hilo ID={Thread.CurrentThread.ManagedThreadId}.");
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(nuevaCarpeta, nombreFichero));
                }
            }
            sw.Stop();
            Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms.");

        }
    }
}
