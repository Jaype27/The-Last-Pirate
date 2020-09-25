using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMortar : MonoBehaviour {

	public float _mortarDistance;
	public GameObject _mortarPrefab;
	public float _mortarFireRate;
	private float _mortarfireRateTimer;
	private Transform _playerTarget;

	// Use this for initialization
	void Start () {
		_playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		MortarDetect();
	}

	void MortarDetect() {
		if(Vector2.Distance(transform.position, _playerTarget.position) < _mortarDistance) {
			MortarShoot();
		}
	}

	void MortarShoot() {
		if(_mortarfireRateTimer <= 0) {
			Instantiate(_mortarPrefab, transform.position, Quaternion.identity);
			_mortarfireRateTimer = _mortarFireRate;
		} else {
			_mortarfireRateTimer -= Time.deltaTime;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _mortarDistance);
	}
}
