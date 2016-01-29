using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager audioManagerInstance = null;   
	public AudioClip[] clips;
	public AudioSource audioSource;

	void Awake()
	{
		//Check if instance already exists
		if (audioManagerInstance == null){
			audioManagerInstance = this;
		}

		//If instance already exists and it's not this:
		else if (audioManagerInstance != this){
			Destroy(gameObject);    
		}
		DontDestroyOnLoad(gameObject);

	}
	void Start(){
		audioSource = GetComponent<AudioSource> () as AudioSource;


	}
	// Update is called once per frame
	void Update () {
	
	}


}
