using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float _launchSpeed;
	private Rigidbody2D _rb2d;
	public float _maxLaunchTime;
	private float _launchTime;


	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		_launchTime = _maxLaunchTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rb2d.velocity = transform.up * _launchSpeed;

		_launchTime -= Time.deltaTime;
		if(_launchTime <= 0f) {
			_rb2d.velocity = Vector2.zero;
		}
	}
}
