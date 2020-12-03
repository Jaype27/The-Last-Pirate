using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject _pauseMenu;

	public void Pause() {
		Time.timeScale = 0f;
		_pauseMenu.SetActive(true);
	}

	public void Resume() {
		Time.timeScale = 1f;
		_pauseMenu.SetActive(false);
	}

	public void Quit() {
		Application.Quit();
	}

	public void Back() {
		this.gameObject.SetActive(false);
	}
}
