using UnityEngine;
using System.Collections;

public class TowerSpot : MonoBehaviour {

	void OnMouseUp (){
		Debug.Log ("TowerSpot clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager> ();

		if (bm.selectedtower != null) {
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager> ();
			if (bm.selectedtower.GetComponent<Tower> () != null) {
				if (sm.money < bm.selectedtower.GetComponent<Tower> ().cost) {
					Debug.Log ("Not enough money!");
					return;
				} else {
					sm.money -= bm.selectedtower.GetComponent<Tower> ().cost;
				}
			}

			if (bm.selectedtower.GetComponent<Tower_Air> () != null) {
				if (sm.money < bm.selectedtower.GetComponent<Tower_Air> ().cost) {
					Debug.Log ("Not enough money!");
					return;
				} else {
					sm.money -= bm.selectedtower.GetComponent<Tower_Air> ().cost;
				}
			}

			if (bm.selectedtower.GetComponent<Lazer> () != null) {
				if (sm.money < bm.selectedtower.GetComponent<Lazer> ().cost) {
					Debug.Log ("Not enough money!");
					return;
				} else {
					sm.money -= bm.selectedtower.GetComponent<Lazer> ().cost;
				}
			}


			Instantiate (bm.selectedtower, transform.position, transform.rotation);
			bm.selectedtower = null;
			Destroy (transform.parent.gameObject);
		}
	}
}
