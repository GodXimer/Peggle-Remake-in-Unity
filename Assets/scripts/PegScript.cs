using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{
    public enum PegType { Normal, Point, Multiplier, PowerUP, LAST };
    public int Points;
    private SpriteRenderer sr;

    public PegType Type { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetType(PegType type)
    {
        Type = type;

        switch (type)
        {
            case PegType.Normal:
                Points = 20;
                sr.color = new Color(0.0f, 0.5f, 1.0f);
                break;
            case PegType.Point:
                Points = 50;
                sr.color = new Color(0.9803922f, 0.5166667f, 0.2470588f);
                break;
            case PegType.Multiplier:
                Points = 100;
                sr.color = Color.magenta;
                break;
            case PegType.PowerUP:
                Points = 250;
                sr.color = new Color(0.0f, 1.0f, 0.0f);
                break;
        }
    }
}
