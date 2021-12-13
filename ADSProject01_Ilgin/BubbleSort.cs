using System;
namespace ADSProject01_Ilgin
{
    public class BubbleSort
    {
        //Bubble sort algorithm to display product list in alphabetical order - Ilgin 22.06.2021
        public static void bubbleSort(Product[] array)
        {
            Product temp;
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].name.CompareTo(array[j + 1].name) > 0)
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }

            }


        }
    }
}
