using System;
using System.Collections.Generic;

namespace POC.Core.Console
{
    using globalConsole = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            globalConsole.WriteLine("Hello World!");

            Base base2 = new Base();
            base2.Show();
            Base.System s = new Base.System();
            new Child().Show();
            new GrandChild().Show();

            #region ReturnByReference

            ReturnByReference returnByReference = new ReturnByReference();
            int[] number = { 1, 3, 5, 6, 3, 2, 12, 34 };
            string[] stringArray = { "a", "b", "c" };
            List<string> stringList = new List<string> { "a", "b", "c" };

            int position = returnByReference.FindInArray(6, number);
            ref int position2 = ref returnByReference.FindInArray(6, number);
            globalConsole.WriteLine($"Position: {position}");
            globalConsole.WriteLine($"Position2: {position2}");
            position = -6;
            globalConsole.WriteLine($"Position: {number[3]}");
            position2 = -6;
            globalConsole.WriteLine($"Position2: {number[3]}");

            ref string stringPosition = ref returnByReference.FindInStringArray("b", stringArray);
            globalConsole.WriteLine($"stringPosition: {stringPosition}");
            globalConsole.WriteLine($"stringPosition: {stringArray[1]}");
            stringPosition = "Pancha Nand";
            globalConsole.WriteLine($"stringPosition: {stringArray[1]}");

            ref string stringListPosition = ref returnByReference.FindInStringArray("b", stringList.ToArray());
            globalConsole.WriteLine($"stringPosition: {stringListPosition}");
            globalConsole.WriteLine($"stringPosition: {stringList[1]}");
            stringPosition = "Pancha Nand";
            globalConsole.WriteLine($"stringPosition: {stringArray[1]}");
            #endregion

            globalConsole.ReadLine();
        }
    }

    class Base
    {
        public virtual void Show() =>
            globalConsole.WriteLine("From Base.");
        public class System
        {
            public void Display() => global::System.Console.WriteLine("From Global Display.");
        }
    }

    class Child : Base
    {
        public override void Show()
            => globalConsole.WriteLine("from Child.");
    }

    class GrandChild : Child
    {
        public override void Show()
       => globalConsole.WriteLine("From GrandChild");
    }
}
