using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private float _enemyHealth;
	public float _maxEnemyHealth;

	// Use this for initialization
	void Start () {
		_enemyHealth = _maxEnemyHealth;
		
	}

	public void DamageTaken(float _dmg) {
		_enemyHealth -= _dmg;

		if(_enemyHealth <= 0) {
			Die();
		}
	}

	void Die() {
		this.gameObject.SetActive(false);
	}
}
