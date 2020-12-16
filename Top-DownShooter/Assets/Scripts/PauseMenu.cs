using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject _pauseMenu;
	public GameObject _controlsMenu;

	public void Pause() {
		Time.timeScale = 0f;
		_pauseMenu.SetActive(true);
	}

	public void Resume() {
		Time.timeScale = 1f;
		_pauseMenu.SetActive(false);
	}

	public void Controls() {
		_controlsMenu.SetActive(true);
	}

	public void Quit() {
		Application.Quit();
	}

	
}
