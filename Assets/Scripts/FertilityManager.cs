using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FertilityManager : MonoBehaviour {
	int [] num = new int [10]; 
	int size;   //size of the array
	int index;  // index of the player in the array 
	int round;
	bool status;

	public Button buttonA;
	public Button buttonB;
	public Button buttonC;

	public AudioClip audioA;
	public AudioClip audioB;
	public AudioClip audioC;

	void Start () {
		// Initializate
		buttonA = GetComponent<Button>();
		buttonB = GetComponent<Button>();
		buttonC = GetComponent<Button>();

		round = 1;
		size = 0;  // firts size
		index = 0;  // firts index
		addRandom(); //initializate array
		status = false; // firts cpu time
	}


	void Update () {
		if (!status) {
			if (round < 4) {
				addRandom ();		
				for (int x = 0; x < size; x++) {
					// TODO Ir dibujando secuencialmente los botones
					Debug.Log (num [x]);
				}
				status = true;
				index = 0;
			} else {
				// TODO Victoria
				Debug.Log("Victoria");
			}
		} 
	}



	// onClicks
	public void OnButtonA() {
		Debug.Log ("Botton A");
		//TODO: Ejecutar sonido
		//buttonA.image.color = new Color (0, 0, 1, 1);
		if (num [index] == 1) {
			Debug.Log ("Acierto");
			index++;
			if (index == size) {
				status = false;
			}
		} else {
			Debug.Log ("Fallo");
		}
	}
	public void OnButtonB() {
		Debug.Log ("Botton B");
		//buttonB.image.color = new Color (0, 0, 1, 1);
		if (num [index] == 2) {
			Debug.Log ("Acierto");
			index++;
			if (index == size) {
				status = false;
			}
		} else {
			Debug.Log ("Fallo");
		}
	}
	public void OnButtonC() {
		Debug.Log ("Botton C");
		//buttonD.image.color = new Color (0, 0, 1, 1);
		if (num [index] == 3) {
			Debug.Log ("Acierto");
			index++;
			if (index == size) {
				status = false;
			}
		} else {
			Debug.Log ("Fallo");
		}
	}



	// Methods
	public void addRandom(){
		num[size] = Random.Range(1,4);
		num[size+1] = Random.Range(1,4);
		size = size+2;
	}
}
