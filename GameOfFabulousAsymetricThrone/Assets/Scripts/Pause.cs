using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject canvasPause;
	bool Paused = false;


	void Start(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if(Paused == true){
				Time.timeScale = 1;
				canvasPause.SetActive (false);
				Paused = false;
			} else {
				Time.timeScale = 0;
				canvasPause.SetActive (true);
				Paused = true;
			}
		}

	}
	public void ReturnUnpause(){
		Time.timeScale = 1;
		canvasPause.SetActive (false);
		Paused = false;
	}
}    

