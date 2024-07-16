using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("El cafe esta listo");
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask
};
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("Los huevos estan listos");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("El tocino esta listo");
                }
                    else if (finishedTask == toastTask)
                    {
                        Console.WriteLine("La tostada esta lista");
                    }
                    await finishedTask;
                    breakfastTasks.Remove(finishedTask);
                }
                Juice oj = PourOJ();
                Console.WriteLine("El jugo esta listo");
                Console.WriteLine("DESALLUNO LISTO!!");
            }
            static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }
            private static Juice PourOJ()
            {
                Console.WriteLine("Jugo de Naranja Pura");
                return new Juice();
            }
            private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Poner mermelada a las tostadas");
            private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Ponerle mantequilla a la tostada");
            private static async Task<Toast> ToastBreadAsync(int slices)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($"Poner la rebanada numero {slice+1} de pan en la tostadora.");
                }
                Console.WriteLine("Empezar a tostar...");
                await Task.Delay(3000);
                Console.WriteLine("Sacar la tostada de la tostadora");
                return new Toast();
            }
            private static async Task<Bacon> FryBaconAsync(int slices)
            {
                Console.WriteLine($"Poner {slices} rebanadas de tocino en la sartén.");
                Console.WriteLine("Cocinar el primer lado del tocino...");
                await Task.Delay(3000);
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($"Voltear la rebanada de tocino numero {slice+1}");
                }
                Console.WriteLine("Cocinar el segundo lado del tocino...");
                await Task.Delay(3000);
                Console.WriteLine("Poner el tocino en el plato");
                return new Bacon();
            }
            private static async Task<Egg> FryEggsAsync(int howMany)
            {
                Console.WriteLine("Calentar la sarten para los huevos...");
                await Task.Delay(3000);
                Console.WriteLine($"Romper {howMany} Huevos");
                Console.WriteLine("Cocinar los huevos ...");
                await Task.Delay(3000);
                Console.WriteLine("Poner los huevos en el plato");
                return new Egg();
            }
            private static Coffee PourCoffee()
            {
                Console.WriteLine("Servir el cafe");
                return new Coffee();
            }
        }
    }