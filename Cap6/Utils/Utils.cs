using System;

namespace Cap6;

class Utils
{

    public static float GetAvg(ref float[][] arr)
    {
        float sum = 0;
        int count = 0;
        foreach (var salon in arr)
        {
            foreach (var calf in salon)
            {
                count++;
                sum += calf;
            }
        }
        return sum / count;
    }

    public static float GetMin(ref float[][] arr)
    {
        float min = arr[0][0];
        foreach (var salon in arr)
        {
            foreach (var calif in salon)
            {
                min = (calif < min) ? calif : min;
            }
        }
        return min;
    }
    public static float GetMax(ref float[][] arr)
    {
        float max = arr[0][0];
        foreach (var salon in arr)
        {
            foreach (var calif in salon)
            {
                max = (calif > max) ? calif : max;
            }
        }
        return max;
    }
}