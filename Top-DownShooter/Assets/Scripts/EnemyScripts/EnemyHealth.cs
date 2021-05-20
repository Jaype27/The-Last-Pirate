using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[Header("Health")]
	private float _enemyHealth;
	public float _maxEnemyHealth;
	public GameObject _lootDrop;
	// public GameObject[] _lootDrop;
	// private float _percentDrop = 95f;

	// Use this for initialization
	void Start () {
		_enemyHealth = _maxEnemyHealth;
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		CannonBall cannonBall = other.gameObject.GetComponent<CannonBall>();

		if(!cannonBall) { return; }

		DamageTaken(cannonBall);
	}

	public void DamageTaken(CannonBall cannonBall) {
		_enemyHealth -= cannonBall.GetDamage();
		cannonBall.Hit();

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

		Instantiate(_lootDrop, transform.position, Quaternion.identity);

		// float rand = Random.Range(0f, 100f);

		// for (int i = 0; i < _lootDrop.Length; i++) {
		// 	if(rand < _percentDrop) {
		// 		Instantiate(_lootDrop[0], transform.position, transform.rotation);
		// 	} else if(rand >= _percentDrop) {
		// 		Instantiate(_lootDrop[1], transform.position, transform.rotation);
		// 	}
		// }
	}
}
