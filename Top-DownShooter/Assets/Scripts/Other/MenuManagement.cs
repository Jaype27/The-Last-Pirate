using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour {

	int _currentSceneIndex;

	public void LoadNextScene() {
		SceneManager.LoadScene(_currentSceneIndex + 1);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
