using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6__8_
{
    class Program
    {
        //функция проверки ввода вещественного числа
        public static double CheckInputDouble(string message, double minValue, double maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            double input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToDouble(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }

        //функция проверки ввода целого числа
        public static int CheckInputInt(string message, int minValue, int maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            int input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToInt16(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }


        //рекурсивное заполнение последовательности
        static void FillSequence(double a1, double a2, double a3, int n,ref double []array)
        //первые элемент, второй элемент, третий элемент,количество элементов, массив для записи элементов
        {
            if (n != 0)
            {
                array[n-1] = a1;//запись элемента в массив
                double a4 = Math.Round(a3 / 3 + a2 / 2 + a1 * 2 / 3, 3);//вычисление следующего элемента 
                FillSequence(a2, a3, a4, n - 1,ref array);
            }
        }

        //рекурсивное заполнение последовательности в массив
        static double[] FillSequenceInArray(double a1, double a2, double a3, int n, double []array)
        //первые элемент, второй элемент, третий элемент,количество элементов, массив для записи элементов
        {
            if (array.Length == n)
            {
                FillSequence(a1, a2, a3, n, ref array);
                Array.Reverse(array);
                return array;
            }
            else
                throw new ArgumentException();
            
        }

        //проверка, какие пары соответсвуют условию
        static void CheckCondition(double [] sequence,double e,ref int count)
        {
            if (sequence != null)
            {
                for(int i = 0; i < sequence.Length-1; i++)
                {
                    if (Math.Abs(sequence[i] - sequence[i + 1]) < e)
                    {
                        count++;
                        Console.Write((i + 1) + " и " + (i + 2)+"\t");
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            //программа строит последовательность элементов

            double a1, a2, a3;//первые три элемента последовательности
            double e;//число для проверки условия
            int n;//количество элементов последовательности

            double[] array;//массив элементов последовательности
            int count = 0;//количество пар, удовлетворяющих условию

            a1 = CheckInputDouble("Введите а1 (от -1000 до 1000)", -1000, 1000);//ввод а1
            a2 = CheckInputDouble("Введите а2 (от -1000 до 1000)", -1000, 1000);//ввод а2
            a3 = CheckInputDouble("Введите а3 (от -1000 до 1000)", -1000, 1000);//ввод а3
            e = CheckInputDouble("Введите e (от -1000 до 1000)", -1000, 1000);//ввод e
            n = CheckInputInt("Введите n (от 3 до 1000)", 3, 1000);//ввод n

            array = new double[n];//выделение памяти под последовательность
            array = FillSequenceInArray(a1, a2, a3, n,array);//заполнение массива элементами последовательности

            Console.WriteLine("Последовательность:");
            foreach (double a in array)//печать последовательности
                Console.Write(a + "\t");

            Console.WriteLine();
            Console.WriteLine("Номера элементов, модуль разности которых меньше e:");
            CheckCondition(array, e, ref count);
            Console.WriteLine();
            Console.WriteLine("Количество пар=" + count);
        }
    }
}
