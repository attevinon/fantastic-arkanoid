using System;
using UnityEngine;

namespace FantasticArkanoid.Utilites
{
    public static class TimeFormatter
    {
        public static string ToMmSs(double time)
        {
            if(time < 0)
            {
                Debug.LogError("Time can't be lower than 0!");
                return null;
            }

            TimeSpan yourTimeSpan = TimeSpan.FromSeconds(time);
            return string.Format("{0:00}:{1:00}", yourTimeSpan.Minutes, yourTimeSpan.Seconds);
        }
    }
}
