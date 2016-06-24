using UnityEngine;
using System.Collections;

public class Bullet_Air : MonoBehaviour {

	public float speed = 10f;
	public Transform target;
	public float damage = 1f;
	public float radius = 0;

	void Update () 
	{
//		transform.Translate(Vector3.forward * Time.deltaTime * mySpeed);
//		myDist += Time.deltaTime * mySpeed;
//		if (myDist >= myRange)
//			Explode ();
//		if(myTarget)
//		{
//			transform.LookAt(myTarget);
//		}
//		else
//		{
//			Explode();
//		}

		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.GetChild(0).position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distThisFrame) {
			DoBulletHit ();
		} else {
			transform.Translate (dir.normalized * distThisFrame,Space.World);
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.deltaTime);
		}
	}

	void DoBulletHit(){
		if (radius == 0) {
			target.GetComponent<Enemy_Air> ().TakeDamage (damage);
		} else {
			Collider[] cols = Physics.OverlapSphere (transform.position, radius);

			foreach (Collider c in cols) {
				Enemy_Air e = c.GetComponent<Enemy_Air> ();
				if (e != null) {
					e.GetComponent<Enemy_Air> ().TakeDamage (damage);
				}
			}
		}

		Destroy (gameObject);
	}
}
