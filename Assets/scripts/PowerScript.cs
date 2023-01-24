using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public Animator animator;
    public bool Boom;

    [Min(1f)]
    public float scaleSpeed=1f;
    public void Init()
    {
        Boom = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Obstacle")
        {
            PegsManager.HittedPeg(col);
        }
    }

    private void Update()
    {
        if (!Boom) gameObject.SetActive(false);
    }
}
