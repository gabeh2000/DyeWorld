using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private const double INITIAL_TIME = 30.0;
    private double currentTime;
    public TMP_Text currentTimeText;
    public const int INTERFACE_SCENE = 0;
    public Transform targetCharacter;

    void Start()
    {
        currentTime = INITIAL_TIME;
        currentTimeText.text = INITIAL_TIME.ToString("F2");
    }

    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        currentTimeText.text = currentTime.ToString("F2");

        if(currentTime <= 0){
            SceneManager.LoadScene(INTERFACE_SCENE);
        }
    }

}