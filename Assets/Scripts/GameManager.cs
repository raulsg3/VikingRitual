using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;   
	public enum Scenes{MainScene, FertilityScene, RainScene, ProvidenceScene, FateScene}
	Scenes currentScene;

    public Text ageText;
    public float ageSpeedFactor = 3.0f;

	public Slider rainSlider;
	public Slider providenceSlider;
	public Slider fertilitySlider;
	public Slider fadeSlider;
	public float maxValuesForAtributes = 20f;
    
	[SerializeField]
    public float age = 0;
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

	void Update(){
        age += Time.deltaTime * ageSpeedFactor;
        ageText.text = ((int)age / 60).ToString();
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
			if (fertilitySlider.value + value <= maxValuesForAtributes) {
				fertilityValue += value;
				fertilitySlider.value = fertilityValue;

			}
			break;
		case Scenes.FateScene:
			if (fadeSlider.value + value <= maxValuesForAtributes) {
				fadeValue += value;
				fadeSlider.value = fadeValue;
			}
			break;
		case Scenes.ProvidenceScene:
			if (providenceSlider.value + value <= maxValuesForAtributes) {
				providenceValue += value;
				providenceSlider.value = providenceValue;
			}
			break;
		case Scenes.RainScene:
			if (rainSlider.value + value <= maxValuesForAtributes) {
				rainValue += value;
				rainSlider.value = rainValue;
			}
			break;
		}

	}

	public float GetProvidence(){
		return providenceValue;
	}
	public float GetFertility(){
		return fertilityValue;
	}
	public float GetFade(){
		return fadeValue;
	}
	public float GetRain(){
		return rainValue;
	}

	void RefreshSlider(){
		fertilitySlider.value = fertilityValue;
		fadeSlider.value = fadeValue;
		providenceSlider.value = providenceValue;
		rainSlider.value = rainValue;

	}
}
