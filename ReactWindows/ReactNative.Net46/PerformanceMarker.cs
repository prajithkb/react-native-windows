using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactNative
{
    public class PerformanceMarker
    {
        static Dictionary<String, Stopwatch> markers = new Dictionary<string, Stopwatch>();

        public static void start(String marker)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            markers.Add(marker, s);
     
        }

        public static long Stop(string marker)
        {
            Stopwatch v;
            if(markers.TryGetValue(marker, out v))
            {
                v.Stop();
                markers.Remove(marker);
                return v.ElapsedMilliseconds;
            }
            else
            {
                return -1;
            }
        }

        public static void Print(string marker)
        {
            Console.WriteLine("PKB time spent {0} - {1} ms", marker,Stop(marker));
        }
    }
}
