using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGO;

	Transform targetpathNode;
	int pathNodeIndex = 0;

	float speed=5f;

	public float health = 3f;
	public int moneyValue=1;

	// Use this for initialization
	void Start () {
		pathGO = GameObject.Find ("Path");
	}

	void GetNextPathNode(){
		if (pathNodeIndex < pathGO.transform.childCount) {
			targetpathNode = pathGO.transform.GetChild (pathNodeIndex);
			pathNodeIndex++;
		} else {
			targetpathNode = null;
			ReachedGoal ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (targetpathNode == null) {
			GetNextPathNode ();
			if (targetpathNode == null) {
				//Khi lính đi tới đích
				ReachedGoal();
				return;
			}
		}

		Vector3 dir = targetpathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distThisFrame) {
			targetpathNode = null;
		} else {
			transform.Translate (dir.normalized * distThisFrame,Space.World);
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.deltaTime);
		}
	}

	void ReachedGoal(){
		GameObject.FindObjectOfType<ScoreManager> ().LoseLife();
		Destroy (gameObject);
	}

	public void TakeDamage(float damage){
		health -= damage;
		if (health <= 0) {
			Die ();
		}
	}

	public void Die(){
		GameObject.FindObjectOfType<ScoreManager> ().money += moneyValue;
		Destroy (gameObject);
	}
}
