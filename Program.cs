using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Question2316402
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = File.ReadAllText(args[0], Encoding.UTF8);
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.ReadKey();
            var pattern = @"[^а-я|a-z]+";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var arr = regex.Split(str.ToLower()).Where(e => e.Length >= 1);
            var query = arr.GroupBy(e => e).Select(e => new { Word = e.Key, Count = e.Count() }).OrderByDescending(e => e.Count);



            var sout = new StringBuilder();
            foreach (var item in query)
            {
                sout.Append($"{item.Word} {item.Count}").AppendLine();

            }


            File.WriteAllText(args[1], sout.ToString(), Encoding.UTF8);

            Console.WriteLine(sout);

            Console.ReadKey();
        }
    }
}