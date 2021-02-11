using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour {

	public Transform _playerTarget;
	public float _forwardSpeed;
	public float _wayPointDistance; // TODO: Change Later
	public float _stopDistance;
	Path _path;
	int _currentWaypoint = 0;
	public bool _reachedEndPath = false;
	public float _repeateRate;

	Seeker _seeker;
	Rigidbody2D _rb2d;

	// Use this for initialization
	void Start () {
		_seeker = GetComponent<Seeker>();
		_rb2d = GetComponent<Rigidbody2D>();
		_reachedEndPath = false;

		FindPlayer();
		InvokeRepeating("UpdatePath", 0f, _repeateRate);
		
		
	}

	void FindPlayer() {
		GameObject _searchPlayer = GameObject.FindGameObjectWithTag("Player");
		if(_searchPlayer != null)
			_playerTarget = _searchPlayer.transform;
	}

	void UpdatePath() {
		if(_seeker.IsDone())
		_seeker.StartPath(_rb2d.position, _playerTarget.position, OnPathComplete);
	}

	void OnPathComplete(Path p) {
		if(!p.error) {
			_path = p;
			_currentWaypoint = 0;
		}
	}

	void Update() {
		if(_playerTarget == null) {
			FindPlayer(); 
			return;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(_path == null)
			return;

		if(_currentWaypoint >= _path.vectorPath.Count) {
			_reachedEndPath = true;
			return;
		} else {
			_reachedEndPath = false;
		}

		Vector2 dir = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb2d.position).normalized;
		Vector2 force = dir * _forwardSpeed * Time.deltaTime;

		if(Vector2.Distance(transform.position, _playerTarget.position) > _stopDistance) {

			_rb2d.AddForce(force);

			float dist = Vector2.Distance(_rb2d.position, _path.vectorPath[_currentWaypoint]);

			if(dist < _wayPointDistance) {
				_currentWaypoint++;
			}

			transform.up = _rb2d.velocity;
		} else {
			transform.up = _playerTarget.position - transform.position;
		}
	}


}
