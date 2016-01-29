using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;   
	private int age = 0;  

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
