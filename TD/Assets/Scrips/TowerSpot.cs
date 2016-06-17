using UnityEngine;
using System.Collections;

public class TowerSpot : MonoBehaviour {

	void OnMouseUp (){
		Debug.Log ("TowerSpot clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager> ();
		if (bm.selectedtower != null) {
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager> ();
			if (sm.money < bm.selectedtower.GetComponent<Tower> ().cost) {
				Debug.Log ("Not enough money!");
				return;
			}
			sm.money -= bm.selectedtower.GetComponent<Tower> ().cost;


			Instantiate (bm.selectedtower, transform.parent.position, transform.parent.rotation);
			Destroy (transform.parent.gameObject);
		}
	}
}
