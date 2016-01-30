using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FertilityManager : MonoBehaviour {
	int [] num = new int [10]; 
	int size;   // size of the array
	int index;  // index of the player in the array 
	int round;
	bool status;
	bool oneFail;

	public Button buttonA;
	public Button buttonB;
	public Button buttonC;

	public Button buttonExit;
	public Button buttonRetry;

	public AudioClip audioA;
	public AudioClip audioB;
	public AudioClip audioC;
	public AudioClip audioVictoria;
	public AudioClip audioDerrota;

	public AudioClip audioBackground;

	public GameObject fxPrefab;
	public Transform spawnPositionA;
	public Transform spawnPositionB;
	public Transform spawnPositionC;
	public Transform spawnPositionTitle;
	public Transform spawnOneFail;

	AudioManager audioManager;

	void Start () {
		// Initializate
		buttonA = GetComponent<Button>();
		buttonB = GetComponent<Button>();
		buttonC = GetComponent<Button>();

		buttonExit = GetComponent<Button>();
		buttonRetry = GetComponent<Button>();

		round = 1;
		size = 0; 
		index = 0; 
		addRandom(); //initializate array
		status = false; // firts cpu time
		oneFail = false; // User can fail 2 times

		audioManager = AudioManager.audioManagerInstance;
		audioManager.StopSound();
		audioManager.PlayBGM(audioBackground);

		// buttonExit.interactable = false;
		// buttonRetry.interactable = false;
	}


	void Update () {
		if (!status) {
			status = true;
			if (round < 4) {
				addRandom ();
				playCPU (0);
			} else {
				endGood();
			}
		} 
	}

	// Play the array notes
	public void playCPU(int x){		
		if (num [x] == 1) {
			audioManager.PlaySound (audioA);
			instanciateEffect(spawnPositionA);
		} else if (num [x] == 2){
			audioManager.PlaySound (audioB);
			instanciateEffect(spawnPositionB);
		} else {
			audioManager.PlaySound (audioC);
			instanciateEffect(spawnPositionC);
		}
		StartCoroutine(Wait(x));
	}

	// Methods
	public void addRandom(){
		num[size] = Random.Range(1,4);
		num[size+1] = Random.Range(1,4);
		size = size+2;
	}
	public void goodButton(){
		index++;
		if (index == size) {
			StartCoroutine(WaitGoodDone());
		}
	}
	public void instanciateEffect(Transform x){
		Destroy (Instantiate (fxPrefab, x.position, x.rotation), 1);
	}


	// Waits Methods
	IEnumerator Wait(int x){
		yield return new WaitForSeconds (2);
		x++;
		if (x < size) {
			playCPU (x);
		} else {
			index = 0;
			round++;
		}
	}
	IEnumerator WaitGoodDone(){		
		yield return new WaitForSeconds (1);
		Destroy (Instantiate (fxPrefab, spawnPositionTitle.position, spawnPositionTitle.rotation), 3);
		yield return new WaitForSeconds (3);
		status = false;
	}


	// Methods End game
	public void endGood(){
		//TODO El usuario Gano
		audioManager.PlaySound (audioVictoria);
		GameManager.instance.SetAttributeValue (1f, GameManager.Scenes.FertilityScene);
		activeMenu ();
		Debug.Log ("VICTORIA");
	}
	public void endFail(){
		//TODO El usuario a fallado el boton a presionar
		audioManager.PlaySound (audioDerrota);
		if (oneFail) {
			GameManager.instance.SetAttributeValue (-2f, GameManager.Scenes.FertilityScene);
			activeMenu ();
			Debug.Log ("DERROTA");
		} else {
			Instantiate (fxPrefab, spawnOneFail.position, spawnOneFail.rotation);
			oneFail = true;
		}
	}

	// onClicks
	public void OnButtonA() {
		audioManager.PlaySound (audioA);
		instanciateEffect(spawnPositionA);
		if (num [index] == 1) {
			goodButton();
		} else {
			endFail();
		}
	}
	public void OnButtonB() {
		audioManager.PlaySound (audioB);
		instanciateEffect(spawnPositionB);
		if (num [index] == 2) {
			goodButton();
		} else {
			endFail();
		}
	}
	public void OnButtonC() {
		audioManager.PlaySound (audioC);
		instanciateEffect(spawnPositionC);
		if (num [index] == 3) {
			goodButton();
		} else {
			endFail();
		}
	}


	// ACTIVE MENU
	public void activeMenu(){
		// buttonExit.gameObject.SetActive (true);
		// buttonRetry.gameObject.SetActive (true);
	}
	public void OnButtonRetry() {
		audioManager.StopBGM ();
		GameManager.instance.Loadscene ("FertilityScene");
	}
	public void OnButtonExit() {
		audioManager.StopBGM ();
		GameManager.instance.LoadMainScene ();
	}
}
