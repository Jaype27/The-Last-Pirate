using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {

	public Transform _player;
	public float _rotationSpeed;

	void Start() {

	}
	
	void Update () {
		if(_player == null) {
			FindPlayer();
			return;
		}

		Vector2 _dir = _player.position - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_dir);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _rotationSpeed * Time.deltaTime);
		transform.right = _dir;

		
		
	}

	void FindPlayer() {
		GameObject _searchPlayer = GameObject.FindGameObjectWithTag("Player");
		if(_searchPlayer != null)
			_player = _searchPlayer.transform;
	}
}
