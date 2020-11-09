using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public bool _gameOver;
	public GameObject _gameOverScreen;
	public Text _livesNumberText;
	public GameObject _playerSpawn;
	public PlayerHealth _player;

	// Use this for initialization
	void Start () {
		_gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		_livesNumberText.text = "Lives: " + PlayerHealth._playerLives;
		
		if (PlayerHealth._playerLives < 0) {
				GameOver();
			}	
	}

	public void GameOver() {
		_gameOver = true;
		_gameOverScreen.SetActive(true);
	}

	public void SpawnPlayer() {
		StartCoroutine(Respawn());
	}

	IEnumerator Respawn() {
		yield return new WaitForSeconds(2);
		_player.transform.position = _playerSpawn.transform.position;
		_player.gameObject.SetActive(true);
		_player.FullHealth();
	} 
}
