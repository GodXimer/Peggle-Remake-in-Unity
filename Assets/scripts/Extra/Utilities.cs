using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static public class Utilities
    {
        static System.Random random;
        static Utilities()
        {
            random = new System.Random();
        }


        static public void ShuffleThis<T>(ref List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int index = random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[index];
                list[index] = temp;
            }
        }

    static public List<T> Shuffled<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int index = random.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[index];
            list[index] = temp;
        }

        return list;
    }

    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }

    public static string RandomString()
    {
        string newName = "";
        for (int i = 0; i < 20; i++)
        {
            char c = (char)('A' + UnityEngine.Random.Range(0, 26));
            newName += c;
        }
        return newName;
    }
}
