using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;
using Interop;

namespace CSharpLibrary
{
    public class Class1
    {
        public int Field1 { get; set; }

        public string Field2 { get; set; }

        public Class1(int x)
        {
            Field1 = x;
        }

        static public bool Method(string name, long count, double weight)
        {
            return true;
        }

        static public void CoreFunctions()
        {
            var xs = SeqModule.Map<int, int>(FSharpFunc<int, int>.FromConverter(x => x * 2), new int[] { 0, 1 });
            Func<int, int> f = x => x * 2;
            var xs2 = SeqModule.Map(f.ToFSharpFunc(), new int[] { 0, 1 });
            var xs3 = SeqModule.Map(Fun.Fun<int, int>(x => x * 2), new int[] { 0, 1 });
            var o = OptionModule.OfObj("foo");
            var o2 = FSharpOption<int>.Some(1);
            var l = ListModule.OfArray(ArrayModule.Create(10, 0));
            ListModule.Map(Fun.Fun<int, int>(x => x + 1), l);
            ListModule.Reduce(Fun.Fun<int, int, int>((x,y) => x + y), l);
        }
    }

    public class FSharpTypes
    {
        public void Test()
        {
            var r = new Interop.FSharpTypes.Record("Ratatosk", 69859);

            var du1 = Interop.FSharpTypes.DU.Case1;
            var du2 = Interop.FSharpTypes.DU.NewCase2("foo");

            foreach (var x in new Interop.FSharpTypes.DU[] { du1, du2})
            {
                if (x.IsCase1)
                {
                    //case 1
                }
                else if (x.IsCase2)
                {
                    //case 2
                }
            }
        }
    }

    public class Num
    {
        private int data;

        public static implicit operator Num(int i)
        {
            return new Num { data = i };
        }

        public static implicit operator Num(string s)
        {
            int result;

            if (int.TryParse(s, out result))
            {
                return new Num { data = result };
            }
            else
            {
                return new Num { data = 999 };
            }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }

    public class FNumTest
    {
        public void Print(Interop.FNum x)
        {
            x.ToString();
        }

        public void Test()
        {
            Print("42");
        }
    }
}


