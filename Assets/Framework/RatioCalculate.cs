using System.Collections;
using System.Collections.Generic;
using System;
public class RatioCalculate
{
    private int totalRatio;
    private List<int> ratioList;

    public RatioCalculate(List<int> ratioList)
    {
        this.ratioList = ratioList;
        totalRatio = 0;
        for (int i = 0; i < ratioList.Count; i++)
        {
            totalRatio += ratioList[i];
        }
    }

    public int GetRandomIndex()
    {
        Random r = new Random();
        int ratio = UnityEngine.Random.Range(0, totalRatio);
        int sum = 0;
        for (int i = 0; i < ratioList.Count; i++)
        {
            sum += ratioList[i];
            if (ratio < sum)
            {
                return i;
            }
        }
        return ratioList.Count - 1;
    }
}
