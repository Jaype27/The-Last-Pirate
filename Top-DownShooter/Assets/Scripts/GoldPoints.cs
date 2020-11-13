using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPoints : MonoBehaviour {

	public int _goldAmount = 1;

	void OnTriggerEnter2D(Collider2D other) {

		PlayerHealth _playerHealth = other.GetComponent<PlayerHealth>();

		if(other.gameObject.tag == "Player") {
			_playerHealth.GoldTaken(_goldAmount);
			this.gameObject.SetActive(false);
		}
	}
}
