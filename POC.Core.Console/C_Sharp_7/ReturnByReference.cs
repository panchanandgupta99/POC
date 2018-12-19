using System;
using System.Collections.Generic;

namespace POC.Core.Console
{
    public class ReturnByReference
    {
        public ref int FindInArray(int value, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                {
                    return ref numbers[i];
                }
            }
            throw new IndexOutOfRangeException();
        }

        public ref string FindInStringArray(string value, string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == value)
                {
                    return ref stringArray[i];
                }
            }
            throw new IndexOutOfRangeException();
        }

        class RefOverloadExample
        {
            public void SampleMethod(int i) { }
            public void SampleMethod(out int i)
            {
                i = 5;
            }
        }

    }
}
