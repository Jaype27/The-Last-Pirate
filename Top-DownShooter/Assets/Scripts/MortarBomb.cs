using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBomb : MonoBehaviour {

	public LayerMask _playerMask;
	public float _mortarSpeed;
	private Transform _playerPosition;
	private Vector2 _playerTarget;
	public float _damageGiven;
	public float _splashRange;

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

	void OnCollisionEnter2D(Collision2D other) {
		Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, _splashRange, _playerMask);

		for(int i = 0; i < _colliders.Length; i++) {
			Rigidbody2D _targetRB = _colliders[i].GetComponent<Rigidbody2D>();
			if(!_targetRB) 
				continue;

			EnemyHealth	_enemtHealth = _targetRB.GetComponent<EnemyHealth>();

			if(!_enemtHealth)
				continue;
			
		}
	}
}
