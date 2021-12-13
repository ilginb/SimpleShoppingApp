using System;
namespace ADSProject01_Ilgin
{
    public class SelectionSort
    {
        //Selection sort descending
        public static void SelectionSort1(Product[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int index_max = i; 
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j].stock > a[index_max].stock)
                    {
                        index_max = j;

                    }


                }
                
                int temp = a[index_max].stock;
                a[index_max].stock = a[i].stock;
                a[i].stock = temp;


            }


        }
    }
}
