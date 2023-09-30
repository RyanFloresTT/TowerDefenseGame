using System;
using System.Collections.Generic;

public static class ListExtensions {
    static Random random = new();
    public static T RandomElement<T>(this List<T> list){
        return list[random.Next(list.Count)];
    }
}
