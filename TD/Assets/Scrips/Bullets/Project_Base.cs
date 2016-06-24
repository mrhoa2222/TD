using UnityEngine;
using System.Collections;

public class Project_Base : MonoBehaviour {

	public GameObject myExplosion ;
	public Transform myTarget;
	public float myRange = 10;
	public float mySpeed = 10;
	public float myDamageAmount = 25;
	public float myDist;

	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag == "Air")
		{
			Explode();
//			other.gameObject.SendMessage("TakeDamage", myDamageAmount, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void Explode()
	{
//		Instantiate(myExplosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
