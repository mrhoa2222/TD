using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;

	Transform flash1;
	ParticleSystem ps1;
	Transform flash2;
	ParticleSystem ps2;

	public float range = 100f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft=0;

	public float damage = 1f;
	public float radius=0;

	// Use this for initialization
	void Start () {
		turretTransform = transform.Find ("Head");
		flash1 = this.transform.GetChild (1).transform.GetChild (0).transform.GetChild (0);
		flash2 = this.transform.GetChild (1).transform.GetChild (1).transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
	
		Enemy[] enemis = GameObject.FindObjectsOfType<Enemy> ();

		Enemy nearstEnemy = null;
		float dist = Mathf.Infinity;

		foreach (Enemy e in enemis) {
			float d = Vector3.Distance (this.transform.position, e.transform.position);
			if (nearstEnemy == null || d < dist) {
				nearstEnemy = e;
				dist = d;
			}
		}
		if (nearstEnemy == null) {
			Debug.Log ("No enemis?");
			return;
		}

		Vector3 dir = nearstEnemy.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation (dir);

		turretTransform.rotation = Quaternion.Euler (0, lookRot.eulerAngles.y, 0);

		fireCooldownLeft -= Time.deltaTime;
		if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt (nearstEnemy);
			ps1 = flash1.GetComponent<ParticleSystem> ();
			ps1.Play ();
			ps2 = flash2.GetComponent<ParticleSystem> ();
			ps2.Play ();
		} else {
			//ps1.Stop ();
			//ps2.Stop ();
		}
	}

	void ShootAt(Enemy e){
		GameObject bullerGO = (GameObject)Instantiate (bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bullerGO.GetComponent<Bullet> ();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;


		//GameObject go = this.transform.GetChild (0).gameObject;
		//Animation ami = go.GetComponent<Animation> ();
		//ami.Play ("Take 001");
		//Debug.Log ("zzzz");
	}
}
