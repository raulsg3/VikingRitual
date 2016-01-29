using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;   
	[SerializeField]
	int age = 0;
	float fertilityValue = 10f;
	float rainValue = 10f;
	float providenceValue = 10f;
	float fadeValue = 10f;


	//Awake is always called before any Start functions
	void Awake()
	{
			//Check if instance already exists
		if (instance == null){
			instance = this;
		}

			//If instance already exists and it's not this:
		else if (instance != this){
			Destroy(gameObject);    
		}
			DontDestroyOnLoad(gameObject);
			InitGame();
	}

	void InitGame(){


	}

	void Update()
	{

	}
}
