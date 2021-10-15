using System;
using System.Diagnostics;

namespace LAB4_2
{
    public class A
    {
        public B[] Arguments;

        public A(B b1, B b2)
        {
            Arguments = new[] { b1, b2 };
        }

        public A(B b1, B b2, B b3)
        {
            Arguments = new[] { b1, b2, b3 };
        }

        public void PrintToDebugPropertiesOfArgs()
        {
            Debug.WriteLine("Properties of arguments:");
            Debug.Indent();

            foreach (var arg in Arguments)
                arg.PrintPropertiesToDebug();

            Debug.Unindent();
        }
    }
    public class B
    {
        public virtual void PrintPropertiesToDebug()
        {
            Debug.WriteLine("B-class hasn't any properties");
        }
    }
    public class C : B
    {
        public string Name { get; set; } = "";

        public C(string name)
        {
            Name = name;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Properties of C-class:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Name)}: {Name}");
            Debug.Unindent();
        }
    }
    public class D : B
    {
        public DateTime TimeOfCreation { get; }

        public D()
        {
            TimeOfCreation = DateTime.Now;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Properties of D-class:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(TimeOfCreation)}: {TimeOfCreation}");
            Debug.Unindent();
        }
    }
    public class E : B
    {
        public uint Id { get; }

        private static uint LastId = 0;

        public E()
        {
            Id = ++LastId;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Properties of E-class:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Id)}: {Id}");
            Debug.Unindent();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A example = new A(
                new B(),
                new C("Third class"),
                new D()


            );

            example.PrintToDebugPropertiesOfArgs();
            Console.ReadLine();
        }
    }
}
