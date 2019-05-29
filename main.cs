using System;
using System.IO;
using System.Collections.Generic;


namespace ctu
{
    static class Unit2
    {
        static int count = 0;
        static int Main(string[] args)
        {
            string q = args[0];
            //Set a Default Playlist
            string[] a = { "Intro", "She Jumps", "She leaps", "She Eats", "She sleeps", "Outro" };

            if ( args.Length == 2 )
                a = FillArray(args[1].Trim());

            Console.WriteLine(string.Format("Playlist: {0} ", string.Join(",", a)));
            Console.WriteLine(string.Format("   Query: {0}",q));
            Console.WriteLine(string.Format("   Index: {0}", Search(a, q)));
            Console.WriteLine(string.Format("  A Size: {0}",a.Length));
            Console.WriteLine(string.Format("   Count: {0}", count));

            return 0;
        }

        public static int Search(string[] a, string q, int iter = 0, int p = 3)
        {
            // Check Bounds for p to length of array
            if ( a.Length < p )
                p = a.Length;
            // Calculate the Max Iteration
            int s = a.Length / p ;

            // If Iteration Grater than Max then q not found
            if (iter > s) 
                return -1;

            // Check for q in the p sublists
            for (int i = p-1; i >= 0; i--)
            {
                count ++;
                // get the current index to compare to
                int index = i * s + iter;
                // Check for array bounds
                if ( index > a.Length-1 )
                    return -1;
                // Compare index contents to q.
                if ( a[index].ToLower() == q.ToLower())
                    return index;

            }

            // Nothing found so Search at next iteration
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











