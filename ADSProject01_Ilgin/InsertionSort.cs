using System;
namespace ADSProject01_Ilgin
{
    public class InsertionSort
    {
        //Insertion sort descending order
        public static void insertionSortDescending(Product[] array)
        {
            int i, j, temp;
            i = 1;
            while (i < array.Length)
            {
                temp = array[i].price;
                j = i - 1;
                while (j >= 0 && array[j].price < temp)
                {
                    array[j + 1].price = array[j].price;
                    j--;
                }
                array[j + 1].price = temp;
                i++;


            }

        }


        //Insertion Sort in ascending order
        public static void insertionSortAscending(Product[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1].price > array[j].price)
                    {
                        int temp = array[j - 1].price;
                        array[j - 1].price = array[j].price;
                        array[j].price = temp;
                    }
                }
            }
        }
    }
}
