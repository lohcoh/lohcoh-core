using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LowKode.Core.Common
{

    /// <summary>
    /// A stupid simple timer I created for diagnosing performance issues.
    /// </summary>
    public class Ttimer : IDisposable
    {
        static Dictionary<string, long> __millis = new Dictionary<string, long>();

        static Stack<Ttimer> __timers = new Stack<Ttimer>();

        Stopwatch timer = new Stopwatch();
        string prefix= "";
        public Ttimer()
        {
            long millis = 0;
            __millis.TryGetValue(prefix, out millis);

            if (__timers.Count <= 0)
            {
                System.Diagnostics.Debug.WriteLine("start:" + prefix + millis);
            }
               

            __timers.Push(this);
            timer.Start();
        }
        public Ttimer(string prefix) 
        {
            this.prefix = prefix;
            long millis = 0;
            __millis.TryGetValue(prefix, out millis);

            if (__timers.Count <= 0)
            {
                System.Diagnostics.Debug.WriteLine("start:" + prefix + millis);
            }
                

            __timers.Push(this);
            timer.Start();
        }

        public void Dispose()
        {
            timer.Stop();

            long millis= 0;
            if (__millis.TryGetValue(prefix, out millis))
                __millis.Remove(prefix);
            
            millis += timer.ElapsedMilliseconds;
            __millis.Add(prefix, millis);

            __timers.Pop();

            if (__timers.Count <= 0)
            {
                foreach (var key in __millis.Keys)
                {
                    System.Diagnostics.Debug.WriteLine((key.Length <= 0 ? "end:" : key) + __millis[key]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }
}
