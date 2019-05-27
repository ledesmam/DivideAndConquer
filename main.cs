using System;
using System.IO;
using System.Collections.Generic;


namespace ctu
{
    static class Unit2
    {
        static int Main(string[] args)
        {
            string n = args[0];
            string[] a = { "She Runs", "She Jumps", "She leaps", "She Eats", "She sleeps", "Fun" };

            if ( args.Length == 2 )
                a = FillArray(args[1].Trim());


            Console.WriteLine(string.Format("Playlist: {0} ", string.Join(",", a)));
            Console.WriteLine(string.Format("   Index: {0}", Search(a, n)));

            return 0;
        }

        public static int Search(string[] a, string q, int iter = 0, int p = 3)
        {
            int s = a.Length / p;
            if (iter > s) return -1;

            for (int i = 0; i < p; i++)
            {
                int index = i * s + iter;
                if ( index > a.Length-1 )
                    return -1;
                else if ( a[index].ToLower() == q.ToLower())
                    return index;

            }

            return Search(a, q, iter + 1, p);
        }




        public static string[] FillArray(string f)
        {

            List<string> l = new List<string>();
            FileStream fs = new FileStream(@f, FileMode.Open, FileAccess.Read);
            using (StreamReader s = new StreamReader(fs))
            {
                string txt;
                while ((txt = s.ReadLine()) != null)
                    l.Add(txt.Trim());
            }

            return l.ToArray(); ;

        }
    }
}











