using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour {

	[SerializeField] int _healthRestore;
	void OnTriggerEnter2D(Collider2D other) {
		PlayerHealth _playerHealth = other.GetComponent<PlayerHealth>();

		if(other.gameObject.tag == "Player") {
			_playerHealth.RestoreHealth(_healthRestore);
			this.gameObject.SetActive(false);
		}
	}
}
