using UnityEngine;
using System.Collections;

public class Bullet_Lazer : MonoBehaviour {

	public float speed = 10f;
	public Transform target;
	public float damage = 1f;
	public float radius = 0;

	public LineRenderer laserLine;
	public GameObject start;
	public GameObject end;

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (1f, 1f);
	}

	// Update is called once per frame
	void Update () {

		if (end != null) {
			laserLine.SetPosition (0, start.transform.position);
			laserLine.SetPosition (1, end.transform.position);
		}
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		target.GetComponent<Enemy> ().TakeDamage (damage);
//		Vector3 dir = target.position - start.transform.position;
//
//		float distThisFrame = speed * Time.deltaTime;
//		if (dir.magnitude <= distThisFrame) {
//			DoBulletHit ();
//		} else {
//			transform.Translate (dir.normalized * distThisFrame,Space.World);
//			Quaternion targetRotation = Quaternion.LookRotation (dir);
//			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.deltaTime);
//		}

	}

//	void DoBulletHit(){
//		if (radius == 0) {
//			target.GetComponent<Enemy> ().TakeDamage (damage);
//		} else {
//			Collider[] cols = Physics.OverlapSphere (transform.position, radius);
//
//			foreach (Collider c in cols) {
//				Enemy e = c.GetComponent<Enemy> ();
//				if (e != null) {
//					e.GetComponent<Enemy> ().TakeDamage (damage);
//				}
//			}
//		}
//		Destroy (gameObject);
//	}
}
