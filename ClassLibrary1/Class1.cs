using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public string name;
        public class Person
        {
            public string Name
            {
                get;
                set;
            }
            public Person()
            {

            }
            public Person(string _name)
            {
                this.Name = _name;
            }
            public void SayHello()
            {
                Console.WriteLine("Hello");
            }
            public void SayHi(string msg)
            {
                Console.WriteLine(msg);
            }
            public void SayHi()
            {
                Console.WriteLine("Hi");
            }
        }
        public class Student : Person
        {

        }
        public delegate void MyDelegate();

    }
}
