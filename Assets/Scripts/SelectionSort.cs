using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    void SelectionS(int[] unsorted)
    {
        int min;
        int temp;

        for (int i = 0; i < unsorted.Length; i++)
        {
            min = i;
            for (int j = i+1; j < unsorted.Length; j++)
            {
                if(unsorted[j] < unsorted[min])
                {
                    min = j;
                }
            }

            if(min != i)
            {
                temp = unsorted[min];
                unsorted[min] = unsorted[i];
                unsorted[i] = temp;
            }
        }
    }
    
    void Start()
    {
        int[] array = new int[] { 5, 3, 7, 1, 9, 4 };
        PrintArray(array);
        SelectionS(array);
        PrintArray(array);
    }

    void PrintArray(int[] array)
    {
        string temp = "";
        for (int i = 0; i < array.Length; i++)
        {
            if(i != array.Length - 1)
            {
                temp += array[i] + ", ";
            }
            else
            {
                temp += array[i];
            }
        }
        print(temp);
    }
}
