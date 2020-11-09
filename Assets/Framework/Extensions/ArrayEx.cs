using System.Collections;
using System.Collections.Generic;
using System;

public static class ArrayEx
{
    public static void Disrupt<T>(this T[] arr, int seed = 0)
    {
        Random r = new Random(seed);

        for (int i = 0; i < arr.Length; i++)
        {
            int index = r.Next(arr.Length);//随机获得0（包括0）到arr.Length（不包括arr.Length）的索引
                                           //Console.WriteLine("index={0}", index);//查看index的值
            T temp = arr[i];  //当前元素和随机元素交换位置
            arr[i] = arr[index];
            arr[index] = temp;
        }
    }

    public static void Disrupt<T>(this List<T> arr, int seed)
    {
        Random r = new Random(seed);

        for (int i = 0; i < arr.Count; i++)
        {
            int index = r.Next(arr.Count);
            T temp = arr[i];
            arr[i] = arr[index];
            arr[index] = temp;
        }
    }

    public static void Disrupt<T>(this List<T> arr)
    {
        Random r = new Random();

        for (int i = 0; i < arr.Count; i++)
        {
            int index = UnityEngine.Random.Range(0, arr.Count);
            T temp = arr[i];
            arr[i] = arr[index];
            arr[index] = temp;
        }
    }
}
