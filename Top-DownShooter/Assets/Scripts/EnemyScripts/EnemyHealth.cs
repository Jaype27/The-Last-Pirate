using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[Header("Health")]
	private float _enemyHealth;
	public float _maxEnemyHealth;
	public GameObject _goldDrop;

	// Use this for initialization
	void Start () {
		_enemyHealth = _maxEnemyHealth;
		
	}

	public void DamageTaken(float _dmg) {
		_enemyHealth -= _dmg;

		if(_enemyHealth <= 0) {
			Instantiate(_goldDrop,transform.position, transform.rotation);
			Die();
		}
	}

	void Die() {
		this.gameObject.SetActive(false);
		WaveManager._enemyRemain--;
		Debug.Log(WaveManager._enemyRemain);
	}
}
