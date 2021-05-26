using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		InvincibleFrames();
		HealthBar();

		if(Input.GetKeyDown(KeyCode.Space)) {
			_playerHealth -= 10;
		}
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

	void OnTriggerEnter2D(Collider2D other) {
		CannonBall cannonBall = other.gameObject.GetComponent<CannonBall>();

		if(!cannonBall) { return; }

		DamageTaken(cannonBall);
	}

	public void DamageTaken(CannonBall cannonBall) {

		if(_invincibleCounter <= 0) {

			_playerHealth -= cannonBall.GetDamage();
			cannonBall.Hit();

			_invincibleCounter = _invincibleMax;

			_playerRend.enabled = false;

			_flashCounter = _flashMax;

			if(_playerHealth <= 0) {
				this.gameObject.SetActive(false);
				_healthBar.gameObject.SetActive(false);
				_gm.SpawnPlayer();
			}
		}
	}

	public void FullHealth() {
		_playerHealth = _maxPlayerHealth;
		_healthBar.gameObject.SetActive(true);
	}
}
