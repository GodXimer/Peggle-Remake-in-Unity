using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomVelocity : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D rb;
    public Vector2 velocity;

    void Start()
    {
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
