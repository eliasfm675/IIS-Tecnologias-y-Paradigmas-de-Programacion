namespace _05DeadlockFix
{
    class Program
    {

        public static void Main()
        {
            decimal cantidadInicial = 30000;
            Cuenta cuentaA = new Cuenta("A", cantidadInicial), cuentaB = new Cuenta("B", cantidadInicial);

            Random random = new Random();
            int iteraciones = 10;
            Thread[] hilos = new Thread[iteraciones];

            //Mitad de transferencias (una por hilo) serán A->B y la otra mitad B->A con cantidades aleatorias.
            for (int i = 0; i < iteraciones; i++)
            {
                decimal cantidad = (decimal)random.NextDouble() * random.Next(1, 600);
                if (i % 2 == 0)
                    hilos[i] = new Thread(() => Transferir(cuentaA, cuentaB, cantidad));
                else
                    hilos[i] = new Thread(() => Transferir(cuentaB, cuentaA, cantidad));
                hilos[i].Name = "Num. transferencia: " + i;
            }

            foreach (Thread hilo in hilos)
                hilo.Start();

            //EJERCICIO:
            // En este proyecto se resuelve el problema del interbloqueo.
            // No obstante, pueden ocurrir efectos no deseados en el método Transferir (atomicidad).

            // Antes: A -> B y B -> A. (primero bloqueábamos origen y luego destino).
            //      Pero origen podría ser A o B y destino, la alternativa.
            //

            //Podríamos establecer un mecanismo para hacer que los lock se bloqueen en el mismo orden. 
            //Es decir:

            //Reciba tanto A -> B como A -> B. Siempre bloquear en el mismo orden: lock (primero) { lock (segundo) { .... }}
            //Pista: atributo número cuenta.

        }

        private static void Transferir(Cuenta cuentaA, Cuenta cuentaB, decimal cantidad)
        {
            Console.WriteLine("Transfiriendo {0:N} euros de la cuenta {1} a la cuenta {2}...",
                cantidad, cuentaA.NumCuenta, cuentaB.NumCuenta);
            if (cuentaA.Transferir(cuentaB, cantidad))
                Console.WriteLine("\tTrasferencia con éxito, hilo: {0}.", Thread.CurrentThread.Name);
            else
                Console.WriteLine("\tTransferencia errónea, hilo: {0}.", Thread.CurrentThread.Name);
        }
    }
}
