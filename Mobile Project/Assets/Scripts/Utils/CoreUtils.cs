using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class CoreUtils
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}

    
