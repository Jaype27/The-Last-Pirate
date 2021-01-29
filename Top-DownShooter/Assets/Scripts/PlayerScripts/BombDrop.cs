using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

	public Transform _firePoint;
	public GameObject _bombPrefab;
	public float _fireRate;
	private float _fireRateTimer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
	}

	void Shoot () {
		if(_fireRateTimer <= 0) {
			if(Input.GetKey(KeyCode.Space)) {
				Instantiate(_bombPrefab, _firePoint.position, _firePoint.rotation);
				_fireRateTimer = _fireRate;
			}
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
		
	}
}
