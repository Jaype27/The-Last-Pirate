using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPoints : MonoBehaviour {

	public int _goldAmount;

	void OnTriggerEnter2D(Collider2D other) {

		PlayerCombat _playerCombat = other.GetComponent<PlayerCombat>();

		if(other.gameObject.tag == "Player") {
			_playerCombat.GoldTaken(_goldAmount);
			this.gameObject.SetActive(false);
		}
	}
}
