using UnityEngine;
using System.Collections;

public class Havoc_rotor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up, 20f, Space.Self);
	}
}
