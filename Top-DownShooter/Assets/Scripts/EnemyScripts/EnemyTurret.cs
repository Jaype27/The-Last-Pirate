using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {

	public Transform _player;
	public float _rotationSpeed;
	public Transform _firePoint;
	[Header("Firerate")]
	public float _fireRate;
	private float _fireRateTimer;
	public float _rayDistance;
	public LayerMask _mask;
	public string _cannonBallPrefabTag;
	PoolManager _poolMG;

	void Start() {
		_poolMG = PoolManager.Instance;
	}
	
	void Update () {
		if(_player == null) {
			FindPlayer();
			return;
		}

		Vector2 _dir = _player.position - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_dir);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _rotationSpeed * Time.deltaTime);
		transform.right = _dir;

		CannonDetect();
	}

	void FindPlayer() {
		GameObject _searchPlayer = GameObject.FindGameObjectWithTag("Player");
		if(_searchPlayer != null)
			_player = _searchPlayer.transform;
	}

	void CannonDetect() {
		RaycastHit2D _hitInfo2d = Physics2D.Raycast(transform.position, transform.right, _rayDistance, _mask);
		if(_hitInfo2d.collider != null) {
			CannonShoot();
			Debug.DrawLine(transform.position, _hitInfo2d.point, Color.red);
		} else {
			Debug.DrawLine(transform.position, transform.position + transform.right * _rayDistance, Color.green);
		}
	}

	void CannonShoot() {
		if(_fireRateTimer <= 0) {
				_poolMG.SpawnFromPool(_cannonBallPrefabTag, _firePoint.position, _firePoint.rotation);				
			_fireRateTimer = _fireRate;
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
	}
}
