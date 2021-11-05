using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Method1 начал работу");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method1 выводит счётчик = {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Method1 закончил работу");
        }
        static void Method2(Task task, object a)
        {
            int n = (int)a;
            Console.WriteLine("Method2 начал работу");
            for (int i = n; i < n + 10; i++)
            {
                Console.WriteLine($"Method2 выводит счётчик = {i}");
                Thread.Sleep(800);
            }
            Console.WriteLine("Method2 закончил работу");

        }
        //static void Method2(int n)
        //{
        //    Console.WriteLine("Method2 начал работу");
        //    for (int i = n; i < n + 10; i++)
        //    {
        //        Console.WriteLine($"Method2 выводит счётчик = {i}");
        //        Thread.Sleep(800);
        //    }
        //    Console.WriteLine("Method2 закончил работу");

        //}
        static int Method3()
        {
            Console.WriteLine("Method3 начал работу");
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                S += i;
                Thread.Sleep(1300);
            }
            Console.WriteLine("Method3 закончил работу");
            return (S);
        }
        static int Method4(int a)
        {
            Console.WriteLine("Method4 начал работу");
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                S += a;
                Thread.Sleep(500);
            }
            Console.WriteLine("Method4 закончил работу");
            return (S);
        }
        static void Main(string[] args)
        {
            //Action action = new Action(Method1); /*Обычный способ с делегатом*/
            //Task task = new Task(action);

            //Task task = new Task(Method1); /*Техника предположения делегата*/

            //Task task = new Task(delegate () { Console.WriteLine("Hello!"); }); /*Анонимный метод*/

            //Task task = new Task(() => Console.WriteLine("Hello!")); /*Лябда выражение*/

            //task.Start(); //"Холодная" задача

            //Task task = Task.Factory.StartNew(action);

            //Task task = Task.Run(action);
            //Task task = new Task(() => Method2(100));
            //task.Start();

            Func<int> func = new Func<int>(Method3);
            Task<int> task = new Task<int>(func);
            task.Start();
            Method1();
            Console.WriteLine(task.Result);
            task.Wait();

            Action action = new Action(Method1);
            Task task1 = new Task(action);
            Action<Task, object> actionTask = new Action<Task, object>(Method2);
            Task task2 = task1.ContinueWith(actionTask,100);
            task1.Start();

            Console.WriteLine("Main закончил работу");
            Console.ReadKey();
        }
    }
}
