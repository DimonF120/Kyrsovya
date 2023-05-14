using System;
using System.IO;
using System.Text;

namespace Kyrsovya
{
    internal class Program
    {
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка перемешиванием
        static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Шейкерная сортировка");
            Console.WriteLine("Выберите способ заполнения: \n"+
                "1. Ручной ввод\n" +
                "2. Чтение из файла");
            int a = Convert.ToInt32(Console.ReadLine());
            string[] parts= {" "};
            if (a == 1)
            {
                Console.Write("Введите элементы массива: ");
                parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (a == 2)
            {
                StreamReader sr = new StreamReader(@"E:\БГУИР\1 курс 2 семестр\ОАиП (курсач)\Kyrsovya\1.txt", Encoding.Default);
                while (!sr.EndOfStream)
                {
                    parts = sr.ReadToEnd().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
                }
                sr.Close();
            }
            else if (a != 1 || a != 2)
            {
                Console.WriteLine("Введённый номер способа не найден");
                Console.ReadLine();
                return;
            }
            var array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }

            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", ShakerSort(array)));

            Console.ReadLine();
        }
    }
}
