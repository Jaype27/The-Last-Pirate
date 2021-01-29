using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[Header("Health")]
	private float _enemyHealth;
	public float _maxEnemyHealth;
	public GameObject[] _lootDrop;
	private float _percentDrop = 95f;

	// Use this for initialization
	void Start () {
		_enemyHealth = _maxEnemyHealth;
		
	}

	public void DamageTaken(float _dmg) {
		_enemyHealth -= _dmg;

		if(_enemyHealth <= 0) {
			SpawnDrop();
			Die();
		}
	}

	void Die() {
		this.gameObject.SetActive(false);
		WaveManager._enemyRemain--;
	}

	void SpawnDrop() {
		float rand = Random.Range(0f, 100f);

		for (int i = 0; i < _lootDrop.Length; i++) {
			if(rand < _percentDrop) {
				Instantiate(_lootDrop[0], transform.position, transform.rotation);
			} else if(rand >= _percentDrop) {
				Instantiate(_lootDrop[1], transform.position, transform.rotation);
			}
		}
	}
}
