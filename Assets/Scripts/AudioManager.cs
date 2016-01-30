using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager audioManagerInstance = null;   
	public AudioSource audioSource;
	public AudioSource audioAmbient;
	public AudioClip ambientSound;
	public AudioSource bgmSound;

	private AudioSource[] allAudioSources;

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
		bgmSound = GetComponent<AudioSource> () as AudioSource;

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(AudioClip audioClip){
		audioSource.PlayOneShot (audioClip);
	}
	public void StopSound(){
		audioSource.Stop ();
	}
	public void StopAmbient(){
	}
	public void PlayBGM(AudioClip audioClip){
		bgmSound.PlayOneShot (audioClip);
	}
	public void StopBGM(){
		bgmSound.Stop ();
	}

}
