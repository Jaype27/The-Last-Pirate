﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

	public static int _playerLives;
	private int _remainingLives = 1;
	private int _goldPoints;
	public Text _goldAmountText;
	public float _maxPlayerHealth;
	private float _playerHealth;
	public Image _healthBar;
	public Renderer _playerRend;
	private float _flashCounter;
	public float _flashMax = 0.1f;
	private float _invincibleCounter;
	public float _invincibleMax = 1.0f;
	public GameManager _gm;

	// Use this for initialization
	void Start () {
		_playerHealth = _maxPlayerHealth;
		_playerLives = _remainingLives;
	}
	
	// Update is called once per frame
	void Update () {
		InvincibleFrames();
		HealthBar();
		_goldAmountText.text = "Gold: " + _goldPoints;
	}

	void InvincibleFrames() {
		if(_invincibleCounter > 0) {
			_invincibleCounter -= Time.deltaTime;

			_flashCounter -= Time.deltaTime;

			if(_flashCounter <= 0) {
				_playerRend.enabled = !_playerRend.enabled;

				_flashCounter = _flashMax;
			}

			if(_invincibleCounter <= 0) {
				_playerRend.enabled = true;
			}
		}
	}

	void HealthBar() {
		_healthBar.fillAmount = _playerHealth / _maxPlayerHealth;
	}

	public void DamageTaken(float _dmg) {

		if(_invincibleCounter <= 0) {
			_playerHealth -= _dmg;

			_invincibleCounter = _invincibleMax;

			_playerRend.enabled = false;

			_flashCounter = _flashMax;

			if(_playerHealth <= 0) {
				this.gameObject.SetActive(false);
				_remainingLives--;
				_gm.SpawnPlayer();
			}
		}
	}

	public void FullHealth() {
		_playerHealth = _maxPlayerHealth;
	}


	public void GoldTaken(int _amnt) {
		_goldPoints += _amnt;
	}
	

}
