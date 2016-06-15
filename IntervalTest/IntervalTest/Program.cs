using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalTest
{
    class Program
    {
        //Всего 12 интервалов с шагом 5
        public static int GetInterval(double value)
        {
            if (value >= 0.0 && value < 30.0)
            {
                if (value >= 0.0 && value < 15.0)
                {
                    if (value >= 0.0 && value < 10.0)
                    {
                        if (value < 5.0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (value >= 15.0 && value < 25.0)
                    {
                        if (value < 20.0)
                        {
                            return 4;
                        }
                        else
                        {
                            return 5;
                        }
                    }
                    else
                    {
                        return 6;
                    }
                }
            }
            else
            {
                if (value >= 30.0 && value < 45.0)
                {
                    if (value >= 30.0 && value < 40.0)
                    {
                        if (value < 35.0)
                        {
                            return 7;
                        }
                        else
                        {
                            return 8;
                        }
                    }
                    else
                    {
                        return 9;
                    }
                }
                else
                {
                    if (value >= 45.0 && value < 55.0)
                    {
                        if (value < 50.0)
                        {
                            return 10;
                        }
                        else
                        {
                            return 11;
                        }
                    }
                    else
                    {
                        return 12;
                    }
                }
            }
        }
    static void Main(string[] args)
        {
            int[] arr = new int[12] { 3, 7, 12, 16, 22, 26, 31, 38, 43, 49, 52, 56 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Value {0} - Interval {1}\n",arr[i], GetInterval(arr[i]));
            }

            Console.ReadKey();
        }
    }
}
