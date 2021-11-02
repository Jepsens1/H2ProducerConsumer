using System;
using System.Threading;

namespace H2ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of ProducerConsumer
            ProducerConsumer producerConsumer = new ProducerConsumer();
            //Creates 2 threads, one for add and one for remove, and then start thread
            Thread producerThread = new Thread(producerConsumer.Add);
            Thread consumerThread = new Thread(producerConsumer.Remove);
            producerThread.Start();
            consumerThread.Start();

        }
    }
}
