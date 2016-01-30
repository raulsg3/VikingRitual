using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FertilityManager : MonoBehaviour {
	int [] num = new int [10];
	int size;
	bool status;

	public Button buttonA;
	public Button buttonB;
	public Button buttonC;
	public ColorBlock colorButtonA;
	public ColorBlock colorButtonB;
	public ColorBlock colorButtonC;

	void Start () {
		// Initializate
		buttonA = GetComponent<Button>();
		buttonB = GetComponent<Button>();
		buttonC = GetComponent<Button>();
		colorButtonA = GetComponent<Button>().colors;
		colorButtonB = GetComponent<Button>().colors;
		colorButtonC = GetComponent<Button>().colors;

		size = 0;  // firts size
		addRandom(); //initializate array
		status = false; // firts cpu time
	}


	void Update () {
		if (!status) {
			addRandom ();		
			for (int x = 0; x < size; x++){
				Debug.Log(num[x]);
			}
			status = true;
		} 
	}

	public void OnButtonA() {
		Debug.Log ("Botton A");
		colorButtonA.highlightedColor = Color.blue;
		colorButtonA.normalColor = Color.cyan;
		colorButtonA.pressedColor = Color.green;
		buttonA.colors = colorButtonA;
	}
	public void OnButtonB() {
		Debug.Log ("Botton B");
		buttonB.colors = Color.blue;
	}
	public void OnButtonC() {
		Debug.Log ("Botton C");
		buttonC.colors = Color.blue;
	}

	public void addRandom(){
		num[size] = Random.Range(1,4);
		num[size+1] = Random.Range(1,4);
		size = size+2;
	}
}
