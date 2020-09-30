using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCannon : MonoBehaviour {

	public Transform _firePoint;
	public GameObject _cannonBallPrefab;
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
			if(Input.GetMouseButtonDown(0)) {
				Instantiate(_cannonBallPrefab, _firePoint.position, _firePoint.rotation);
				_fireRateTimer = _fireRate;
			}
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
		
	}
}
