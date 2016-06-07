using UnityEngine;
using System.Collections;

public class BuldingManager : MonoBehaviour {

	public GameObject selectedtower;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectTowerType(GameObject prefab){
		selectedtower = prefab; 
	}
}
