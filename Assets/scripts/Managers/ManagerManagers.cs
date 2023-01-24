using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerManagers : MonoBehaviour
{
    [Header("Balls Manager")]
    [SerializeField] private Transform pegsParent;
    [SerializeField] private Prediction prediction;
    [SerializeField] private Material hittedMaterial;
    [SerializeField] private float ratePegs = 0.75f;

    [Header("TextManager")]
    [SerializeField] private TextMeshProUGUI debugText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ballsText;
    [SerializeField] private TextMeshProUGUI multText;

    [Header("GameManager")]
    [SerializeField] private GameObject explosion;

    [Header("SoundManager")]
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        PegsManager.Init(pegsParent, prediction, hittedMaterial, ratePegs);
        TextManager.Init(debugText,scoreText,ballsText,multText);
        GameManager.Init(explosion);
        SoundManager.Init(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        TextManager.Update();
    }
}
