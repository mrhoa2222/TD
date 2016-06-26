using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedtower;
	public GameObject towerSelect;

	public void SelectTowerType(GameObject prefab){
		selectedtower = prefab; 
	}

	public void BackToMenu(){
		Application.LoadLevel ("Menu");
	}

	public void Sell(){
		Animator ani = GameObject.Find ("Upgrade_Canvas").transform.GetChild (0).GetComponent<Animator> ();
		ani.enabled = true;
		ani.Play ("PanelOut");
		Destroy (towerSelect.gameObject);
	}

	public void Upgrade(){
		Animator ani = GameObject.Find ("Upgrade_Canvas").transform.GetChild (0).GetComponent<Animator> ();
		ani.enabled = true;
		ani.Play ("PanelOut");
		towerSelect.GetComponent<Tower> ().damage += 10;
	}
}
