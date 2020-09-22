using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float _enemyHealth;
	public Transform[] _firePoint;
	public GameObject _cannonBallPrefab;
	public float _fireRate;
	private float _fireRateTimer;
	public float _rayDistance;
	public LayerMask _mask;
	public float _forwardSpeed;
	public float _rotationSpeed;
	private Rigidbody2D _rb2d;

	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		Physics2D.queriesStartInColliders = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(_fireRateTimer <= 0) {
			for(int i = 0; i < _firePoint.Length; i++) {
				Instantiate(_cannonBallPrefab, _firePoint[i].position, _firePoint[i].rotation);
			}
			_fireRateTimer = _fireRate;
		} else {
			_fireRateTimer -= Time.deltaTime;
		}

		// CannonDetect();
		// ShipMovement();

		// Ray _rayDetect = new Ray (transform.position, transform.up);
		// RaycastHit _hitInfo;

		// if(Physics.Raycast(_rayDetect, out _hitInfo, 100, _mask, QueryTriggerInteraction.Ignore)) {
		// 	print(_hitInfo.collider.gameObject.name);
		// 	Destroy(_hitInfo.collider.gameObject);
		// 	Debug.DrawLine(_rayDetect.origin, _hitInfo.point, Color.red);
		// } else {
		// 	Debug.DrawLine(_rayDetect.origin, _rayDetect.origin + _rayDetect.direction * 100, Color.green);
		// }
	}

	void CannonDetect() {
		RaycastHit2D _hitInfo2d = Physics2D.Raycast(transform.position, -transform.right, _rayDistance);
		if(_hitInfo2d.collider != null) {
			Shoot();
			Debug.DrawLine(transform.position, _hitInfo2d.point, Color.red);
		} else {
			Debug.DrawLine(transform.position, transform.position - transform.right * _rayDistance, Color.green);
		}
	}

	void Shoot() {
		if(_fireRateTimer <= 0) {
			for(int i = 0; i < _firePoint.Length; i++) {
				Instantiate(_cannonBallPrefab, _firePoint[i].position, _firePoint[i].rotation);
			}
			_fireRateTimer = _fireRate;
		} else {
			_fireRateTimer -= Time.deltaTime;
		}
	}



	void ShipMovement() {
		
			_rb2d.velocity = transform.up * _forwardSpeed;

	}
	
	void ShipRotation() {

		transform.Rotate(0, 0, -_rotationSpeed);
	}
}
