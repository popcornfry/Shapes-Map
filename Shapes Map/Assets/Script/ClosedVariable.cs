using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedInteger
{
    private int _value;
    private int max;
    private int min;
    private int range;

    // delegate int DIFF_ABS(int a, int b);
    // DIFF_ABS dIFF_ABS = (min, max) =>
    //     {
    //         return min > max ? min - max : max - min;
    //     };

    public ClosedInteger(int min, int max)
    {
        this.min = min;
        this.max = max;
        range = DIFF_ABS(min, max);
    }

    private int DIFF_ABS(int a, int b)
    {
        return (a > b ? a - b : b - a);
    }

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            int newValue = _value + value;

            if (0 < value && max < newValue)
            {
                _value = newValue - range;
                Debug.Log($"Overflow\n value: {value}, _value: {_value}, newValue: {newValue}, min + newValue: {min + newValue}");
            }
            else
            {
                _value = value;
            }

            // if (minNum > temp)
            // {
            //     _value = maxNum + temp;
            //     Debug.Log($"Underflow, {temp}");
            // }
            // else if (maxNum < temp)
            // {
            //     _value = minNum + temp;
            //     Debug.Log($"Overflow, {temp}");
            //     // _value = minNum + rem;
            // }
            // else
            // {
            //     _value = value;
            //     Debug.Log("Nomal");
            // }
        }
    }

    public int Max
    {
        set
        {
            max = value;
            range = DIFF_ABS(min, max);
        }
    }

    public int Min
    {
        set
        {
            min = value;
            range = DIFF_ABS(min, max);
        }
    }
}
