using UnityEngine;
using System.Collections;

public class VikingsManager : MonoBehaviour {
	public GameObject[] vikings;
	private int numOfVikings;
	// Use this for initialization
	void Start () {
		numOfVikings = vikings.Length;
		RefreshVikings ();
		StartCoroutine ("RefreshVikingsAlongGame");
	}
	

	void RefreshVikings(){
		float pointsByAttributes = GameManager.instance.GetFade () + GameManager.instance.GetFertility() + GameManager.instance.GetProvidence () + GameManager.instance.GetRain ();
		//int numbOfVikings = ExtensionMethods.Remap
		float numOfVikings = ExtensionMethods.Remap(pointsByAttributes, 0f, GameManager.instance.maxValuesForAtributes * 4f, 0f, vikings.Length);
		Debug.Log ("Numero de vikingos" + numOfVikings.ToString ());

		int numOfCurrentVikingsAbles = 0;
		for (int i = 0; i < vikings.Length; i++) {
			if (vikings [i].activeInHierarchy  == true) {
				numOfCurrentVikingsAbles++;
			}

		}

		int numOfVikingToPush = (int)numOfVikings - numOfCurrentVikingsAbles;

		if (numOfVikingToPush > 0) {
			ActiveVikings (numOfVikingToPush);
		} else {
			DisactiveVikings (Mathf.Abs(numOfVikingToPush));
		}

	}
	void ActiveVikings(int vinkingToActive){
		int vikingsActivated = 0;
		for (int i = 0; i < vikings.Length; i++) {
			if (vikings [i].activeInHierarchy == false && vikingsActivated <= vinkingToActive) {
				vikings [i].SetActive(true);
				vikingsActivated++;
			}

		}

	}

	void DisactiveVikings(int vinkingToDisactive){
		int vikingsDisactivated = 0;
		for (int i = 0; i < vikings.Length; i++) {
			if (vikings [i].activeInHierarchy == true && vikingsDisactivated <= vinkingToDisactive) {
				vikings [i].SetActive(false);
				vikingsDisactivated++;
			}

		}
	}

	IEnumerator RefreshVikingsAlongGame(){
		while (true) {
			RefreshVikings ();
			yield return new WaitForSeconds(5f);

		}
	}
}
public static class ExtensionMethods {

	public static float Remap (this float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

}
