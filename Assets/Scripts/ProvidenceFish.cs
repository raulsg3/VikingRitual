using UnityEngine;
using System.Collections;

public class ProvidenceFish : MonoBehaviour {

    public float lifeTime = 5.0f;
    private ProvidenceManager providenceManager;
    
    // Use this for initialization
    void Start () {
        providenceManager = GameObject.FindGameObjectWithTag("ProvidenceManager").GetComponent<ProvidenceManager>();

        StartCoroutine(DestroyFish());
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator DestroyFish()
    {
        // Waiting...
        yield return new WaitForSeconds(lifeTime);
        providenceManager.fishLost();
    }

}
