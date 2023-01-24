using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceLookMouse : MonoBehaviour
{
    private List<Sprite> faces;
    private Sprite[] spritesFaces; 

    [SerializeField] private int faceIndex;
    [SerializeField] private SpriteRenderer thisSprite;
    private Transform lookAtPosition;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    void Start()
    {
        faces = new List<Sprite>(2);

        spritesFaces = Resources.LoadAll<Sprite>($"Faces");

        ChangeFace(faceIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - lookAtPosition.position).x > 1)
        {
            thisSprite.sprite = faces[0];
            thisSprite.flipX = false;
        }
        else if ((transform.position - lookAtPosition.position).x < -1)
        {
            thisSprite.sprite = faces[0];
            thisSprite.flipX = true; 
        }
        else
        {
            thisSprite.sprite = faces[1];
            thisSprite.flipX = false; 
        }

        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                ChangeFace(i);
            }
        }
    }

    void ChangeFace(int faceID)
    {
        int startIndex = faceID * 2;

        if (spritesFaces.Length <= startIndex) return;

        faces.Clear();

        for (int i = startIndex; i < startIndex + 2; i++)
        {
            faces.Add(spritesFaces[i]);
        }
    }

    public void SetPositonToLook(Transform transform)
    {
        lookAtPosition = transform;
    }
}
