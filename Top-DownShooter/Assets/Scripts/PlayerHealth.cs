using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float _maxPlayerHealth = 100f;
	public float _playerHealth;

	public Renderer _playerRend;
	private float _flashCounter;
	public float _flashMax = 0.1f;
	private float _invincibleCounter;
	public float _invincibleMax = 1.0f;

	// Use this for initialization
	void Start () {
		_playerHealth = _maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		InvincibleFrames();
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

	public void PlayerDamage(float _dmg) {

		if(_invincibleCounter <= 0) {
			_playerHealth -= _dmg;

			_invincibleCounter = _invincibleMax;

			_playerRend.enabled = false;

			_flashCounter = _flashMax;

			if(_playerHealth <= 0) {
				this.gameObject.SetActive(false);
			}
		}
	}

}
