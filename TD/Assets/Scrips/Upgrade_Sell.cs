using UnityEngine;
using System.Collections;

public class Upgrade_Sell : MonoBehaviour {

	public GameObject turret;
	public GameObject circle;
	GameObject go;
	Animator ani;

	// Use this for initialization
	void OnMouseDown(){
		go = (GameObject)Instantiate (circle, new Vector3 (this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z),this.transform.rotation);
		float towerRadius = this.GetComponent<Tower> ().range;

		go.GetComponent<DrawCircle> ().radius = towerRadius;
		go.transform.Rotate (Vector3.left, 90f);

		ani = GameObject.Find ("Upgrade_Canvas").transform.GetChild (0).GetComponent<Animator> ();
		ani.enabled = true;
		ani.Play ("PanelIn");
		turret = GameObject.Find ("_SCRIPS_");
		turret.GetComponent<BuildingManager> ().towerSelect = this.transform.gameObject;
	}

	void OnMouseUp(){
//		ani = GameObject.Find ("Upgrade_Canvas").transform.GetChild (0).GetComponent<Animator> ();
//		ani.enabled = true;
//		ani.Play ("PanelOut");
		Destroy (go);
	}
}
