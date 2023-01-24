using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int speed = 2;
    [SerializeField] private SpriteRenderer spriteRenderer;
    float limitX;
    float halfWidth;
    float halfHeight;
    float orthographicHeight;

    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        limitX = Camera.main.orthographicSize * Camera.main.aspect;
        orthographicHeight = Camera.main.orthographicSize;
        transform.position = new Vector3(0, -orthographicHeight, 0);

        halfWidth = spriteRenderer.bounds.size.x * 0.5f;
        halfHeight = spriteRenderer.bounds.size.y * 0.5f;

        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - halfWidth < -limitX)
        {
            //sotto zero
            transform.position = new Vector3(-limitX+halfWidth, -orthographicHeight, 0);
            Bounce();
        }
        else if(transform.position.x + halfWidth > limitX)
        { 
            //sopra limite
            transform.position = new Vector3(limitX-halfWidth, -orthographicHeight, 0);
            Bounce();
        }
    }

    void Bounce()
    {
        speed = -speed;
        rb.velocity = new Vector2(speed, 0);
    }
}
