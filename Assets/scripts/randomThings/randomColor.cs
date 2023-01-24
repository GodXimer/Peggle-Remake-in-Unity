using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Color version
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );

        GetComponent<SpriteRenderer>().color = randomColor;
    }
}
