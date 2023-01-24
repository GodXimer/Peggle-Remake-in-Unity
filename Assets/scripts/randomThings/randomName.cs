using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomName : MonoBehaviour
{
    [HideInInspector] public bool IsGhost;
    static private int Id = 612;

    public void Init()
    {
        if (IsGhost) return;

        name = Id.ToString();
        Id+=2;
    }
}
