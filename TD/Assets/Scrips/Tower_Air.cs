using UnityEngine;
using System.Collections;

public class Tower_Air : MonoBehaviour {

	Transform turret_Air;

	public float range = 20f;
	public AudioClip clip;
	public GameObject bulletPrefab;
	public Transform[] muzzlePositions;

	public int cost = 5;

	Enemy_Air nearstEnemy = null;
	public float fireCooldown = 0.1f;
	float fireCooldownLeft=0;

	public float damage = 1;
	public float radius=0;

	// Use this for initialization
	void Start () {
		turret_Air = transform.Find ("Head");
		//flash1 = this.transform.GetChild (1).transform.GetChild (0);
	}

	// Update is called once per frame
	void Update () {

		Enemy_Air[] enemis = GameObject.FindObjectsOfType<Enemy_Air> ();

		if (nearstEnemy == null) {
			float i = range;
			foreach (Enemy_Air e in enemis) {
				float d = Vector3.Distance (this.transform.position, e.transform.position);
				if (d < i) {
					nearstEnemy = e;
					i = d;
				}
			}
		}
		if (nearstEnemy == null) {
			//Debug.Log ("No enemis?");
			return;
		}

		Vector3 dir = nearstEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation (dir);

		if (Vector3.Distance (this.transform.position, nearstEnemy.transform.position) <= range) {
			turret_Air.rotation = Quaternion.Euler (0, lookRot.eulerAngles.y, 0);
		} else {
		}

		fireCooldownLeft -= Time.deltaTime;

		if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt (nearstEnemy);
		}

		if (dir.magnitude > range)
			nearstEnemy = null;
	}

	void ShootAt(Enemy_Air e){
		int m  = Random.Range(0,2);
		GameObject newMissile = (GameObject)Instantiate (bulletPrefab, muzzlePositions [m].position, muzzlePositions [m].rotation);

		Bullet_Air b = newMissile.GetComponent<Bullet_Air> ();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;

		this.transform.GetComponent<AudioSource> ().PlayOneShot (clip, 0.1f);
	}
}
