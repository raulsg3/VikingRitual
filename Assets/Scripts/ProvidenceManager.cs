using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProvidenceManager : MonoBehaviour
{
    // Gameplay variables
    public float waitTime = 2.0f;
    public int totalSuccess = 10;

    //Audios
    public AudioClip audioVictoria;
    public AudioClip audioDerrota;
    private int numSuccess = 0;
    private bool previousFail = false;

    // User feedback
    public Text textSuccess;
    public Image imageFailure;

    public Button buttonExit;
    public Button buttonRetry;

    // List of spawn points
    public Transform spawnPointList;
    private List<Transform> spawnPoints = new List<Transform>();

    // Fish prefab
    public Rigidbody fish;

    // Scene name
    private string strScene = "ProvidenceScene";

    // Use this for initialization
    void Awake ()
    {
        // Initialize the list of spawn points
        foreach (Transform child in spawnPointList) {
            child.forward = Vector3.forward;
            spawnPoints.Add(child);
        }
    }

	void Start ()
    {
        StartCoroutine(GenerateFishes());

        //Feedback
        updateTextSuccess();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Transform transformHit = hit.transform;

                if (transformHit.tag == "ProvidenceFish") {
                    fishSuccess();
                    Destroy(transformHit.gameObject);
                }
            }
        }
    }
    
    IEnumerator GenerateFishes()
    {
        while (numSuccess < totalSuccess)
        {
            // Waiting...
            yield return new WaitForSeconds(waitTime);

            // Get random spawn point from the list
            int rndIndex = Random.Range(0, spawnPoints.Count);
            Transform rndSpawnPoint = spawnPoints[rndIndex];

            // Create the new fish in that point
            Rigidbody newFish = Instantiate<Rigidbody>(fish);
            newFish.transform.position = rndSpawnPoint.position + rndSpawnPoint.forward * 2;
            newFish.transform.forward = rndSpawnPoint.forward;

            newFish.velocity = newFish.transform.forward * 5.0f;
        }
    }

    public void fishSuccess()
    {
        ++numSuccess;
        updateTextSuccess();

        if (numSuccess >= totalSuccess)
        {
            Debug.Log("Success");
            activateEndButtons();
            GameManager.instance.SetAttributeValue(2.0f, GameManager.Scenes.ProvidenceScene);
            AudioManager.audioManagerInstance.PlaySound(audioVictoria);
        }
    }

    public void fishLost()
    {
        if (!previousFail)
        {
            previousFail = true;
            imageFailure.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Fail");
            activateEndButtons();
            GameManager.instance.SetAttributeValue(-1.0f, GameManager.Scenes.ProvidenceScene);
            AudioManager.audioManagerInstance.PlaySound(audioDerrota);
        }
    }

    private void updateTextSuccess()
    {
        textSuccess.text = numSuccess + " / " + totalSuccess;
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

    private void activateEndButtons()
    {
        buttonExit.gameObject.SetActive(true);
        buttonRetry.gameObject.SetActive(true);
    }

}
