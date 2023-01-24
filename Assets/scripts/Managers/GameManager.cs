using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static public class GameManager
{
    static public float ActualMultiplier
    { 
        get => multiplier; 
        set {
            multiplier = value;
            TextManager.SetMulty(multiplier);
        }
    }
    static private float multiplier;

    static public int ActualScore
    {
        get => score;
        set
        {
            score = value;
            TextManager.SetScore(score);
        }
    }
    static private int score;

    static public GameObject Explosion;


    static public void Init(GameObject explosion)
    {
        ActualMultiplier = 1;
        ActualScore = 0;

        Explosion = explosion;
    }

}

