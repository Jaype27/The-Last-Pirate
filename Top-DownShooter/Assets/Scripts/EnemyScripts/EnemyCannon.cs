using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour {

	public Transform[] _firePoint;
	[Header("Firerate")]
	public float _fireRate;
	private float _fireRateTimer;
	public float _rayDistance;
	public LayerMask _mask;
	public string _cannonBallPrefabTag;
	PoolManager _poolMG;


	// Use this for initialization
	void Start () {
		Physics2D.queriesStartInColliders = false;
		_poolMG = PoolManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		CannonDetect();
	}

	void CannonDetect() {
		RaycastHit2D _hitInfo2d = Physics2D.Raycast(transform.position, transform.up, _rayDistance, _mask);
		if(_hitInfo2d.collider != null) {
			CannonShoot();
			Debug.DrawLine(transform.position, _hitInfo2d.point, Color.red);
		} else {
			Debug.DrawLine(transform.position, transform.position + transform.up * _rayDistance, Color.green);
		}
		_fireRateTimer -= Time.deltaTime;
	}

	void CannonShoot() {
		if(_fireRateTimer <= 0) {
			for(int i = 0; i < _firePoint.Length; i++) {
				_poolMG.SpawnFromPool(_cannonBallPrefabTag, _firePoint[i].position, _firePoint[i].rotation);				
			}
			_fireRateTimer = _fireRate;
		}
	}
}
