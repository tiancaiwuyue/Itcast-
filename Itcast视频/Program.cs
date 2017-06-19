using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Itcast视频
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "HelloWorld";
            BinaryFormatter bf = new BinaryFormatter();
            //1.1创建一个文件流
            using (FileStream fsWrite = new FileStream("person.bin", FileMode.Create))
            {
                //2.开始执行序列化
                bf.Serialize(fsWrite, p1);
            }
            Console.WriteLine("序列化完毕！");
            Console.ReadKey();

        }
    }


    [Serializable] public class Animal
    {
        void Eat() { }
    }
    [Serializable] public class Person:Animal
    {
        public Car Mercedes
        {
            get;
            set;
        }
        public string Name { get; set; }
        // [NonSerialized] 不能标记在属性前

        //public int Age { get; set; }

        [NonSerialized] private int _age;       
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public MyClass SayHello(MyClass mc)
        {
            return new MyClass();
        }
    }
    public class MyClass
    {

    }
    [Serializable] public class Car
    {

    }
}
