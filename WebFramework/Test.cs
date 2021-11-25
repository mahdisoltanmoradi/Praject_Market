using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFramework
{
    public class Person:Action
    {
        public string  name { get; set; }
        public int age { get; set; }

        public void Add(string name)
        {
            Console.WriteLine(name + "Salam");
        }
    }

    public interface Action
    {
        void Add(string name);
        void SendMessage(string name)
        {
            Console.WriteLine(name + "Salam");
        }
    }
}
