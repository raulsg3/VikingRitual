﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FateManager : MonoBehaviour
{
    // Gameplay variables
    public float waitTime = 2.0f;
    public int totalSuccess = 10;
    public AudioClip audioVictoria;
    public AudioClip audioDerrota;

    private int numSuccess = 0;

    // User feedback
    public Text textSuccess;
    public Image imageFailure;

    // List of spawn points
    public Transform spawnPointList;
    private List<Transform> spawnPoints = new List<Transform>();

    // Ship and enemy prefab
    public GameObject ship;
    public GameObject enemy;

    // List of enemies
    private List<FateEnemy> enemies = new List<FateEnemy>();

    private string strScene = "FateScene";
    // Use this for initialization
    void Awake()
    {
        // Initialize the list of spawn points
        foreach (Transform child in spawnPointList)
        {
            child.forward = Vector3.Normalize(ship.transform.position - child.position);
            spawnPoints.Add(child);
        }
    }

    void Start()
    {
        StartCoroutine(GenerateEnemies());

        //Feedback
        updateTextSuccess();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerateEnemies()
    {
        while (numSuccess < totalSuccess)
        {
            // Waiting...
            yield return new WaitForSeconds(waitTime);

            // Get random spawn point from the list
            int rndIndex = Random.Range(0, spawnPoints.Count);
            Transform rndSpawnPoint = spawnPoints[rndIndex];

            // Create the new enemy in that point
            GameObject newEnemy = Instantiate<GameObject>(enemy);
            newEnemy.transform.position = rndSpawnPoint.position + rndSpawnPoint.forward * 2;
            newEnemy.transform.forward = rndSpawnPoint.forward;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnButtonRetry()
    {
        GameManager.instance.Loadscene(strScene);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnButtonExit()
    {
        GameManager.instance.LoadMainScene();
    }


    public void enemyDestroyed()
    {
        ++numSuccess;
        updateTextSuccess();

        if (numSuccess >= totalSuccess)
        {
            Debug.Log("Success");
            AudioManager.audioManagerInstance.PlaySound(audioVictoria);
            GameManager.instance.SetAttributeValue(-1.0f, GameManager.Scenes.FateScene);
        }
    }

    private void updateTextSuccess()
    {
        textSuccess.text = numSuccess + " / " + totalSuccess;
    }
}
