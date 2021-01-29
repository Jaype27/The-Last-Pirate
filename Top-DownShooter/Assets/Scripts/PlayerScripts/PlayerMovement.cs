using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float _forwardSpeed;
	public float _reverseSpeed;
	public float _rotationSpeed;
	private float _input;
	private Rigidbody2D _rb2d;

	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ShipRotation();
		ShipMovement();
	}



	void ShipMovement() {
		
		if(Input.GetKey(KeyCode.W)) {
			_input = 1;
			_rb2d.velocity = transform.up * _forwardSpeed * _input;
		}

		if(Input.GetKey(KeyCode.S)) {
			_input = -1;
			_rb2d.velocity = transform.up * _reverseSpeed * _input;
		}
	}
	
	void ShipRotation() {
		_input = Input.GetAxisRaw("Horizontal");
		transform.Rotate(0, 0, -_rotationSpeed * _input);
	}
}
