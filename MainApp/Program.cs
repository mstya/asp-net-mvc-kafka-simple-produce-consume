using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
            {
                {"bootstrap.servers", "localhost:9092"}
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                string text = null;
                var rand = new Random();
                //while (text != "exit")
                //{
                //    Console.Write("Write: ");
                //    text = Console.ReadLine();
                //    producer.ProduceAsync("hello-topic", null, text);
                //}

                while (true)
                {
                    string val = rand.Next(0, 100).ToString();
                    Console.WriteLine(val);
                    producer.ProduceAsync("hello-topic", null, val);

                    Thread.Sleep(100);
                }

                producer.Flush(100);
            }
        }
    }
}
