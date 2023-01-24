using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 oldMousePosition;
    private Vector3 newMousePosition;
    [SerializeField] private bool useMouse;

    private void Start()
    {
        if (!useMouse)
        {
            return;
        }
            
        oldMousePosition = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (!useMouse)
        {
            return;
        }

        newMousePosition = GetMousePos();

        if (oldMousePosition != newMousePosition)
        {
            oldMousePosition = transform.position;
            transform.position = newMousePosition;
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
