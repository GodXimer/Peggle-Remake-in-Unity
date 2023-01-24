using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private string scene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(scene,LoadSceneMode.Single); 
    }
}
