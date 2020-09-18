using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public float _speed;
	private Rigidbody2D rb2d;
	public float _activeSpan;
	private float _activeTimer;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		_activeTimer = _activeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = transform.up * _speed;

		_activeTimer -= Time.deltaTime;
		if(_activeTimer <= 0f) {
			this.gameObject.SetActive(false);
		}
	}
}
