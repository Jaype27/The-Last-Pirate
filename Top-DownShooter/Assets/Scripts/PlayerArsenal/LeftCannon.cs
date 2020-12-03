using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCannon : MonoBehaviour {

	
	public Transform _firePoint;
	public GameObject _cannonBallPrefab;
	public float _fireRate;
	private float _fireRateTimer;
	PoolManager _poolMG;
	public AudioSource[] _soundEffect;
	
	// Use this for initialization
	void Start () {
		_poolMG = PoolManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
	}

	void Shoot () {
		if(_fireRateTimer <= 0) {
			if(Input.GetMouseButtonDown(0)) {
				_poolMG.SpawnFromPool("p_cannonball", _firePoint.position, _firePoint.rotation);
				_soundEffect[Random.Range(0, _soundEffect.Length)].Play();
				// Instantiate(_cannonBallPrefab, _firePoint.position, _firePoint.rotation);
				_fireRateTimer = _fireRate;
			}
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
		
	}
}
