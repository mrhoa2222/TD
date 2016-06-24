using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedtower;
	public Canvas menuCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectTowerType(GameObject prefab){
		selectedtower = prefab; 
	}

	public void BackToMenu(){
		Application.LoadLevel ("Menu");
	}
}
