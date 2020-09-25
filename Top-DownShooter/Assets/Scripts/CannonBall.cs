using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public float _speed;
	private Rigidbody2D rb2d;
	public float _activeSpanLife;
	private float _activeTimer;
	public float _damageGiven;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		_activeTimer = _activeSpanLife;
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = transform.up * _speed;

		_activeTimer -= Time.deltaTime;
		if(_activeTimer <= 0f) {
			this.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			this.gameObject.SetActive(false);
			// Damage Player
			
		}

		EnemyHealth _enemyHealth = other.GetComponent<EnemyHealth>();

		if(other.gameObject.tag == "Enemy") {
			_enemyHealth.DamageTaken(_damageGiven);
			this.gameObject.SetActive(false);
			// Damage Enemy
			
		}

		if(other.gameObject.tag == "Obstacle") {
			this.gameObject.SetActive(false);
			
		}
	}
}
