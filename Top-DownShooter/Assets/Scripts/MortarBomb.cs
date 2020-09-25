using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBomb : MonoBehaviour {

	public float _mortarSpeed;
	private Transform _playerPosition;
	private Vector2 _playerTarget;

	// Use this for initialization
	void Start () {
		_playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
		_playerTarget = new Vector2(_playerPosition.position.x, _playerPosition.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, _playerTarget, _mortarSpeed * Time.deltaTime);

		if(transform.position.x == _playerTarget.x && transform.position.y == _playerTarget.y) {
			Destroy(gameObject);
		}
	}
}
