using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static int _playerLives = 1;
	public bool _gameOver;
	public GameObject _gameOverScreen;
	public Text _livesNumberText;
	public GameObject _playerSpawn;
	public PlayerHealth _player;
	public WaveManager _wm;

	// Use this for initialization
	void Start () {
		_gameOver = false;
		_playerLives = 1;
	}
	
	// Update is called once per frame
	void Update () {
		_livesNumberText.text = "Lives: " + _playerLives;

	}

	public void GameOver() {
		_gameOver = true;
		_gameOverScreen.SetActive(true);
		_wm.enabled = false;
		return;
	}

	public void SpawnPlayer() {
		StartCoroutine(Respawn());
	}

	IEnumerator Respawn() {

		if (_playerLives <= 0) {
			GameOver();
		} else {
			yield return new WaitForSeconds(2);
			_player.transform.position = _playerSpawn.transform.position;
			_player.gameObject.SetActive(true);
			_playerLives--;
			_player.FullHealth();
		}
	} 

	public void Retry() {
		_gameOver = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
