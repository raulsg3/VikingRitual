using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;   
	public enum Scenes{MainScene, FertilityScene, RainScene, ProvidenceScene, FadeScene}
	Scenes currentScene;
	public Slider rainSlider;
	public Slider providenceSlider;
	public Slider fertilitySlider;
	public Slider fadeSlider;



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

	void Start(){
	}

	void InitGame(){


	}


	public void Loadscene(string SceneName){
		
		SceneManager.LoadScene(SceneName);
	}

	public void LoadMainScene(){
		SceneManager.LoadScene("MainScene");
	}

	public void SetAttributeValue(float value, Scenes newScene){
		switch(newScene)
		{
		case Scenes.FertilityScene:
			fertilityValue = value;
			fertilitySlider.value = value;
			break;
		case Scenes.FadeScene:
			fadeValue = value;
			fadeSlider.value = value;
			break;
		case Scenes.ProvidenceScene:
			providenceValue = value;
			providenceSlider.value = value;
			break;
		case Scenes.RainScene:
			rainValue = value;
			rainSlider.value = value;
			break;
		}

	}
		
}
