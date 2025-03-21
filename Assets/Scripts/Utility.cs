using System.Collections.Generic;

public static class Utility
{
    public static void Shuffle<T>(List<T> list)
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < list.Count; i++)
        {
            int j = rand.Next(list.Count);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}