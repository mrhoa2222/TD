using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;
	//Animation an;

	Transform flash1;
	ParticleSystem ps1;


	public float range = 20f;
	public AudioClip clip;
	public GameObject bulletPrefab;

	public int cost = 5;

	Enemy nearstEnemy = null;
	public float fireCooldown = 0.1f;
	float fireCooldownLeft=0;

	public float damage = 1;
	public float radius=0;

	// Use this for initialization
	void Start () {
		turretTransform = transform.Find ("Head");
		flash1 = this.transform.GetChild (1).transform.GetChild (0);
		ps1 = flash1.GetComponent<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {

		Enemy[] enemis = GameObject.FindObjectsOfType<Enemy> ();
		if (nearstEnemy == null) {
			float i = range;
			foreach (Enemy e in enemis) {
				float d = Vector3.Distance (this.transform.position, e.transform.position);
				if (d <i) {
					nearstEnemy = e;
					i = d;
				}
			}
		}

		if (nearstEnemy == null) {
			//Debug.Log ("No enemis?");
			ps1.Stop();
			return;
		}

		Vector3 dir = nearstEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation (dir);

		if (Vector3.Distance (this.transform.position, nearstEnemy.transform.position) <= range) {
			turretTransform.rotation = Quaternion.Euler (0, lookRot.eulerAngles.y, 0);
		} else {
			ps1.Stop ();

		}
			
		fireCooldownLeft -= Time.deltaTime;

		if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt (nearstEnemy);
		}
		if (dir.magnitude > range) {
			nearstEnemy = null;
		}
		
	}

	void ShootAt(Enemy e){
		GameObject bullerGO = (GameObject)Instantiate (bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bullerGO.GetComponent<Bullet> ();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;

		ps1.Play ();
		this.transform.GetComponent<AudioSource> ().PlayOneShot (clip, 0.5f);
		//an = transform.GetComponent<Animation> ();
		//an.Play ();
	}
}
