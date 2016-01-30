using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FateManager : MonoBehaviour {

    // List of spawn points
    public Transform spawnPointList;
    private List<Transform> spawnPoints = new List<Transform>();

    // Ship and enemy prefab
    public GameObject ship;
    public GameObject enemy;

    // List of enemies
    private List<FateEnemy> enemies = new List<FateEnemy>();

    // Use this for initialization
    void Awake ()
    {
        // Initialize the list of spawn points
        foreach (Transform child in spawnPointList) {
            child.forward = Vector3.Normalize(ship.transform.position - child.position);
            spawnPoints.Add(child);
        }
    }

	void Start ()
    {
        StartCoroutine(GenerateEnemies(1.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator GenerateEnemies(float waitTime)
    {
        while (true)
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
}
