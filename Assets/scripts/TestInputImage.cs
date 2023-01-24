using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestInputImage : MonoBehaviour
{
    // Get the latest webcam shot from outside "Friday's" in Times Square

    [SerializeField] RawImage image;

    void Start()
    {
        int randomImage = Random.Range(0, 1029);

        string url = "https://picsum.photos/id/"+ randomImage +"/400/400";

        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            image.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            image.color = Color.white;
        }    
    }

    static public Sprite TexToSprite(Texture2D tex)
    {
        tex.Reinitialize(400, 400);

        Rect rect = new Rect(0, 0, tex.width, tex.height);

        Sprite palle = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));

        return palle;
    }

}
