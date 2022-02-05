using System;
using System.Collections;

namespace Ejercicio1;

class Utils
{

    public static float? GetAvg(ArrayList arr)
    {
        float? sum = 0;
        int count = 0;
        foreach (var salon in arr)
        {
            foreach (float? calf in salon as ArrayList)
            {
                count++;
                sum += calf;
            }
        }
        return sum / count;
    }

    public static float? GetMin(ArrayList arr)
    {
        var firstArr = arr[0] as ArrayList;
        var min = firstArr[0] as float?;
        foreach (var salon in arr)
        {
            foreach (float? calif in salon as ArrayList)
            {
                min = ((calif < min) ? calif : min) as float?;
            }
        }
        return min;
    }
    public static float? GetMax(ArrayList arr)
    {
        var firstArr = arr[0] as ArrayList;
        var max = firstArr[0] as float?;

        foreach (var salon in arr)
        {
            foreach (float? calif in salon as ArrayList)
            {
                max = (calif > max) ? calif : max;
            }
        }
        return max;
    }

}