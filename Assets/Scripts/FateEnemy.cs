using UnityEngine;
using System.Collections;

public class FateEnemy : MonoBehaviour {

    // Gameplay variables
    public float speed = 2.0f;

    public FateManager fateManager;
    
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FateProjectile")
        {
            Destroy(this.gameObject);
            fateManager.enemyDestroyed();
        }
    }

}
