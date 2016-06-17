using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int lives = 20;
	public int money = 100;

	public Text moneyText;
	public Text livesText;

	public void LoseLife(){
		lives -= 1;
		if (lives <= 0) {
			GameOver ();
		}
	}

	public void GameOver(){
		Debug.Log ("Game Over");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money: $" + money.ToString();
		livesText.text = "Lives " + lives.ToString();
	}
}
