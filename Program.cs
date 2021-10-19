using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


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

            Assembly asm = Assembly.LoadFrom("ClassLibraryTest.dll");

            Type magicType = asm.GetType("ClassLibraryTest.ClassCounter");
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

            MethodInfo magicMethod = magicType.GetMethod("Counter", BindingFlags.Instance | BindingFlags.NonPublic);

            object magicValue = magicMethod.Invoke(magicClassObject, new object[] { str });

            
            var ordered = (Dictionary<string, int>)magicValue;

            var sout = new StringBuilder();
            foreach (KeyValuePair<string, int> kvp in ordered)
            {

                sout.Append($"{kvp.Key} {kvp.Value}").AppendLine();

            }

            File.WriteAllText(args[1], sout.ToString(), Encoding.UTF8);

            Console.WriteLine(sout);

            Console.ReadKey();
        }
    }
}