using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour {



	void OnTriggerEnter(Collider col){

		Transform go1 = this.transform.GetChild (1).transform.GetChild (0).transform.GetChild (0);
		ParticleSystem ps1= go1.GetComponent<ParticleSystem> ();
		Transform go2 = this.transform.GetChild (1).transform.GetChild (1).transform.GetChild (0);
		ParticleSystem ps2 =go2.GetComponent<ParticleSystem> ();
		if (col.tag == "enemy") {
			ps1.Play ();
			ps2.Play ();
		}
	}
}
