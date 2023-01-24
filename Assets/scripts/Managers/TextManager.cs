using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

static class TextManager
{
    static private TextMeshProUGUI debugText;
    static private TextMeshProUGUI scoreText;
    static private TextMeshProUGUI ballsText;
    static private TextMeshProUGUI multText;

    static private float debugTextTimer;
    static private float debugTextCounter;
    static private bool shouldTick;



    static public void Init(TextMeshProUGUI textDebug, TextMeshProUGUI textScore, TextMeshProUGUI textBalls, TextMeshProUGUI multyText)
    {
        debugText = textDebug;
        scoreText = textScore;
        ballsText = textBalls;
        multText = multyText;

        debugTextTimer = 1;
        debugTextCounter = debugTextTimer;
    }

    static public void Update()
    {
        if (shouldTick && debugTextCounter > 0)
        {
            debugTextCounter -= Time.deltaTime;

            if (debugTextCounter < 0)
            {
                debugText.gameObject.SetActive(false);
                debugTextCounter = debugTextTimer;
                shouldTick = false;
            }

        }
    }
    static public void SendText(string text, float timer = -1)
    {
        shouldTick = true;
        debugText.gameObject.SetActive(true);
        debugText.text = text;

        if (timer > -1)
        {
            debugTextCounter = timer;
        }
    }

    static public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    static public void SetBalls(int balls)
    {
        ballsText.text = "Balls: " + balls;
    }

    static public void SetMulty(float multy)
    {
        multText.text = "Score x " + multy;
    }
}


