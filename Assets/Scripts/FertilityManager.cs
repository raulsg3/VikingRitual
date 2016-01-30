using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FertilityManager : MonoBehaviour {
	int [] num = new int [10]; 
	int size;   // size of the array
	int index;  // index of the player in the array 
	int round;
	bool status;

	public Button buttonA;
	public Button buttonB;
	public Button buttonC;

	public AudioClip audioA;
	public AudioClip audioB;
	public AudioClip audioC;
	public AudioClip audioVictoria;
	public AudioClip audioDerrota;

	void Start () {
		// Initializate
		buttonA = GetComponent<Button>();
		buttonB = GetComponent<Button>();
		buttonC = GetComponent<Button>();

		round = 1;
		size = 0; 
		index = 0; 
		addRandom(); //initializate array
		status = false; // firts cpu time
	}


	void Update () {
		if (!status) {
			if (round < 4) {
				addRandom ();		
				for (int x = 0; x < size; x++) {						
					Debug.Log (num[x]);
					if (num [x] == 1) {
						AudioManager.audioManagerInstance.PlaySound (audioA);
						// TODO Dibujar boton A	
					} else if (num [x] == 2){
						AudioManager.audioManagerInstance.PlaySound (audioB);
						// TODO Dibujar boton B
					} else {
						AudioManager.audioManagerInstance.PlaySound (audioC);
						// TODO Dibujar boton C
					}
				}
				status = true;
				index = 0;
			} else {
				endGood();
			}
		} 
	}



	// onClicks
	public void OnButtonA() {
		AudioManager.audioManagerInstance.PlaySound (audioA);
		// TODO Dibujar boton A	
		if (num [index] == 1) {
			goodButton();
		} else {
			endFail();
		}
	}
	public void OnButtonB() {
		AudioManager.audioManagerInstance.PlaySound (audioB);
		// TODO Dibujar boton B
		if (num [index] == 2) {
			goodButton();
		} else {
			endFail();
		}
	}
	public void OnButtonC() {
		AudioManager.audioManagerInstance.PlaySound (audioC);
		// TODO Dibujar boton C
		if (num [index] == 3) {
			goodButton();
		} else {
			endFail();
		}
	}



	// Methods
	public void addRandom(){
		num[size] = Random.Range(1,4);
		num[size+1] = Random.Range(1,4);
		size = size+2;
	}

	public void goodButton(){
		Debug.Log ("Acierto");
		index++;
		if (index == size) {
			status = false;
		}
	}



	// Methods End game
	public void endGood(){
		//TODO El usuario Gano
		AudioManager.audioManagerInstance.PlaySound (audioVictoria);
		Debug.Log ("VICTORIA");
	}
	public void endFail(){
		//TODO El usuario a fallado el boton a presionar
		AudioManager.audioManagerInstance.PlaySound (audioDerrota);
		Debug.Log ("DERROTA");
	}
}
