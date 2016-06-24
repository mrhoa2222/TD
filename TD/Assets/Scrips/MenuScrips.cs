using UnityEngine;
using System.Collections;

public class MenuScrips : MonoBehaviour {

	public Canvas menuCanvas;

	void Start(){
		menuCanvas.enabled = false;
	}
	public void PauseGame(){
		menuCanvas.enabled = true;
		Time.timeScale = 0;
	}

	public void ResumeGame(){
		menuCanvas.enabled = false;
		Time.timeScale = 1;
	}

	public void RestartGame(){
		Application.LoadLevel ("Scene3");
		Time.timeScale = 1;
	}

	public void MainMenu(){
		Application.LoadLevel ("LevelMenu");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
