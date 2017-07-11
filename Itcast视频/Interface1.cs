using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast视频
{
    public interface Interface1
    {
        void SayHi();
        String Name { get; set; }
        string this[int index] { set;get; }
        event Action MyEvent;

    }
    public class MyClass0 : Interface1
    {
        public string this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action MyEvent;

        public void SayHi()
        {
            throw new NotImplementedException();
        }
    }
}
