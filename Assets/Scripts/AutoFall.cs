using UnityEngine;
using System.Collections;

public class AutoFall : MonoBehaviour {
    
    public float timeUntilFall = 2.0f;
    
    void Start() {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        // Waiting...
        yield return new WaitForSeconds(timeUntilFall);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity *= -1; 
    }
}
