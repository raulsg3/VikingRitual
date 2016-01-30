﻿using UnityEngine;
using System.Collections;

public class RainManager : MonoBehaviour
{
    #region variables configurables de la escena
    public float fFloorSpeed = 0.0f;
    public float fJumpHeight = 2.0f;
    public float fTuneSpawnObj = 0.0f;
    public GameObject goPlayer;
    public GameObject goMoebiusStrip;
    #endregion

    private bool bStartAnim;
    private bool bJummping;
    private float fRainSliderValue = 0.0f;
    private string strScene = "RainScene";
    // Use this for initialization
    void Start()
    {
        bStartAnim = false;
        bJummping = false;
        fRainSliderValue = GameManager.instance.GetRain();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bJummping = goPlayer.GetComponent<Playercontroller>().bFalling;
        if (Input.GetMouseButtonDown(0) && !bJummping)
        {
            //Comprobamos que unicamente se lanze la animación de inicio cuando corresponda
            if (!bStartAnim)
                goMoebiusStrip.GetComponent<Animator>().SetTrigger("StartTrigger");

            bJummping = true;
            StartCoroutine(goPlayer.GetComponent<Playercontroller>().iJump(fJumpHeight));

        }

    }

    /// <summary>
    /// Controlamos la velocidad del suelo y cuando debe parar
    /// </summary>
    private void FloorSpeed()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public void ReStart()
    {
        GameManager.instance.SetAttributeValue(fRainSliderValue, GameManager.Scenes.RainScene);
        GameManager.instance.Loadscene(strScene);
    }

    /// <summary>
    /// 
    /// </summary>
    public void ExitScene()
    {
        GameManager.instance.SetAttributeValue(fRainSliderValue, GameManager.Scenes.RainScene);
        GameManager.instance.LoadMainScene();
    }

    /// <summary>
    /// Asignamos el valor obtenido 
    /// en caso de victoria +2 
    /// en caso de derrota -1
    /// </summary>
    /// <param name="value"></param>
    public void setRainSliderValue(float value)
    {
        fRainSliderValue = fRainSliderValue + value;
    }
}