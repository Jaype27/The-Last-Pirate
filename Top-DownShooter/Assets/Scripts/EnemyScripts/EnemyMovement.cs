using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float _forwardSpeed;
	public float _reverseSpeed;
	public float _rangeDistance;
	public float _minRangeDistance;
	public float _tooCloseToAlly;
	private Rigidbody2D _rb2d;
	private Transform _playerTarget;
	private Transform _allyTarget;

	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		_playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		_allyTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
	}
	
	// Update is called once per frame
	void Update () {
		ShipMovement();
	}

	void ShipMovement() {
		

		if(Vector2.Distance(transform.position, _playerTarget.position) > _rangeDistance) {
			transform.position = Vector2.MoveTowards(transform.position, _playerTarget.position, _forwardSpeed * Time.deltaTime);
			transform.up = _playerTarget.position - transform.position;
			 
		} else if(Vector2.Distance(transform.position, _playerTarget.position) < _rangeDistance && Vector2.Distance(transform.position, _playerTarget.position) > _minRangeDistance) {
			transform.right = _playerTarget.position - transform.position;
			_rb2d.velocity = transform.up * -_forwardSpeed;
		
		} else if(Vector2.Distance(transform.position, _playerTarget.position) <= _minRangeDistance) {
			transform.position = Vector2.MoveTowards(transform.position, _playerTarget.position, -_reverseSpeed * Time.deltaTime);
			transform.up = _playerTarget.position - transform.position;
		}

		// Double Thinking about this
		if(Vector2.Distance(transform.position, _allyTarget.position) <= _tooCloseToAlly) {
			transform.position = Vector2.MoveTowards(transform.position, _allyTarget.position, -_reverseSpeed * Time.deltaTime);
			// transform.up = _allyTarget.position - transform.position;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _rangeDistance);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, _minRangeDistance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, _tooCloseToAlly);
	}
}
