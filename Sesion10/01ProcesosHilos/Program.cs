using System.Diagnostics;

namespace _01ProcesosHilos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Obtenemos los procesos del sistema -> Process[]
            var procesos = Process.GetProcesses();
            //Para cada proceso
            foreach (var proceso in procesos)
            {
                Console.WriteLine($"PID: {proceso.Id}\tNombre: {proceso.ProcessName}\tMemoria: {proceso.VirtualMemorySize64 / 1024.0 / 1024} MB");

                //Cada hilo del proceso
                ProcessThreadCollection hilosProceso = proceso.Threads;
                foreach (ProcessThread hilo in hilosProceso)
                    Console.WriteLine($"\t HiloID: {hilo.Id}\tPrioridad: {hilo.CurrentPriority}\tEstado: {hilo.ThreadState}");
            }
        }
    }
}
