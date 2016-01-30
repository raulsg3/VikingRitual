using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    
    public float delay = 2.0f;
    
    void Start() {
        Destroy(this.gameObject, delay);
    }
}
