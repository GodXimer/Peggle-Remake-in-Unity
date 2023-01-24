using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeToObstaclesChildrens : MonoBehaviour
{
    void Awake()
    {
        WithForLoop();
    }

    void WithForLoop()
    {
        int children = transform.childCount;
        for (int i = 1; i < children; ++i)
        {
            Transform thisChild = transform.GetChild(i);

            randomName randomname = thisChild.gameObject.AddComponent<randomName>();
            randomname.Init();
            thisChild.gameObject.AddComponent<PegScript>();
        }
    }
}
