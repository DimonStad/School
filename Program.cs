using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Test
{
    class Program 
    {
        static void Main(string[] args)
        {
            var str = File.ReadAllText(args[0], Encoding.UTF8);
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.ReadKey();


            // Дергаем приватный метод
            /*Assembly asm = Assembly.LoadFrom("ClassLibraryTest.dll");

            Type magicType = asm.GetType("ClassLibraryTest.ClassCounter");
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

            MethodInfo magicMethod = magicType.GetMethod("Counter", BindingFlags.Instance | BindingFlags.NonPublic);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            object magicValue = magicMethod.Invoke(magicClassObject, new object[] { str });


            var ordered = (Dictionary<string, int>)magicValue;*/
            // Дернули приватный метод


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var ordered = ClassLibraryTest.ClassCounter.Counter_2(str);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            var sout = new StringBuilder();
            foreach (KeyValuePair<string, int> kvp in ordered)
            {

                sout.Append($"{kvp.Key} {kvp.Value}").AppendLine();

            }

            File.WriteAllText(args[1], sout.ToString(), Encoding.UTF8);

            Console.WriteLine(sout);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadKey();
        }
    }
}