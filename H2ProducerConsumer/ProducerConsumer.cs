using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2ProducerConsumer
{
    class ProducerConsumer
    {
        int item = 0;
        int maxamount = 6;
        int totalcount = 0;
        object _lock = new object();
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public void Add()
        {
            while (true)
            {
                //Locks
                Monitor.Enter(_lock);
                try
                {
                    //checks to see if item is equal or more than max required, if true, then wait, else produce
                    if (item >= maxamount)
                    {
                        Console.WriteLine("Full..Producer cant produce anymore");
                        Monitor.Wait(_lock);
                    }
                    item += r.Next(1,6);
                    Console.WriteLine($"Produced {item} item.....Count: {totalcount}");
                    Monitor.PulseAll(_lock);
                    Thread.Sleep(3000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
        public void Remove()
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(_lock);
                    //checks to see if item is empty, if true, wait for production, else consume
                    if (item <= 0)
                    {
                        Console.WriteLine("Production is empty");
                        Monitor.Wait(_lock);
                    }
                    item -= r.Next(1,3);
                    Console.WriteLine($"Consumed {item} item....Count: {totalcount}");
                    Monitor.PulseAll(_lock);
                    Thread.Sleep(3000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
    }
}
