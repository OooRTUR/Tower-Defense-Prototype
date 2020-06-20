
using System;

public  static class CompareFunc
{
    public static Func<float,float,bool> GetCompareFloatFunc(CompareMode compareMode)
    {
        Func<float,float,bool> compareFunc = null;
        
        switch (compareMode)
        {
            case CompareMode.Less:
                compareFunc = delegate (float value, float triggerValue)
                {                    
                    return value < triggerValue;
                };
                break;

            case CompareMode.LessThan:
                compareFunc = delegate(float value, float triggerValue)
                {
                    return value <= triggerValue;
                };
                break;

            case CompareMode.Equal:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value == triggerValue;
                };
                break;

            case CompareMode.More:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value >= triggerValue;
                };
                break;

            case CompareMode.MoreThan:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value > triggerValue;
                };
                break;
        }
        return compareFunc;
    }

    public static Func<int, int, bool> GetCompareIntFunc(CompareMode compareMode)
    {
        Func<int, int, bool> compareFunc = null;
        switch (compareMode)
        {
            case CompareMode.Less:
                compareFunc = delegate (int value, int triggerValue)
                {
                    return value < triggerValue;
                };
                break;
            case CompareMode.LessThan:
                compareFunc = delegate (int value, int triggerValue)
                {
                    return value <= triggerValue;
                };
                break;
            case CompareMode.Equal:
                compareFunc = delegate (int value, int triggerValue)
                {
                    return value == triggerValue;
                };
                break;
            case CompareMode.More:
                compareFunc = delegate (int value, int triggerValue)
                {
                    return value >= triggerValue;
                };
                break;
            case CompareMode.MoreThan:
                compareFunc = delegate (int value, int triggerValue)
                {
                    return value > triggerValue;
                };
                break;
        }
        return compareFunc;
    }
}