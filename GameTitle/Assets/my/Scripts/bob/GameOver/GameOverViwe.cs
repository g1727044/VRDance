﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverViwe : MonoBehaviour
{
    private bool onOff = false;
    private int timeCount = 0;
    public int timeCountMax = 5;
    private NoiseController noiseController;
    public AudioSource MainSound;

    public GameObject sceneChangeObj;

    void Start()
    {
        GameObject childObject = transform.Find("GameOverUI").gameObject;
        noiseController = childObject.GetComponent<NoiseController>();
    }

    void Update()
    {
        if (0 > PlDamageStage.Life)
        {
            //if (onOff)
            //{
            //    onOff = false;
            //    MainSound.volume = 0.272f;
            //}
            if(!onOff)
            {
                onOff = true;
                MainSound.Pause();
            }
            //Time.timeScale = 0;
            GameObject.Find("GameOverUI").GetComponent<UnityEngine.UI.Image>().enabled = onOff;
            noiseController.noiseOnOff = onOff;
        }

        if (onOff)
        {
            timeCount++;

            if (timeCount >= timeCountMax * 60)
            {
                Time.timeScale = 1;
                DissolveControl();
                //SceneManager.LoadScene("SelectScene");
            }
        }
    }
    //フェイドアウトする
    void DissolveControl()
    {
        sceneChangeObj.GetComponent<SceneChangeEffect>().changeSceneName = "SelectScene";
        sceneChangeObj.GetComponent<SceneChangeEffect>().fadeMode = SceneChangeEffect.FADE_MODE.Out;
        sceneChangeObj.GetComponent<SceneChangeEffect>().OnTrigger();
    }
}