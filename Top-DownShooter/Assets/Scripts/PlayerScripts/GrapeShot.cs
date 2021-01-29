using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeShot : MonoBehaviour {

	public Transform[] _firePoint;
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
		for(int i = 0; i < _firePoint.Length; i++) {
			_firePoint[i].gameObject.SetActive(true);
		}

		if(_fireRateTimer <= 0) {
			if(Input.GetMouseButtonDown(0)) {
				for(int i = 0; i < _firePoint.Length; i++) {
					_poolMG.SpawnFromPool("p_cannonball", _firePoint[i].position, _firePoint[i].rotation);
					_soundEffect[Random.Range(0, _soundEffect.Length)].Play();
					_fireRateTimer = _fireRate;
				}
			}
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
	}

}
