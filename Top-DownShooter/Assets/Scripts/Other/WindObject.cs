using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObject : MonoBehaviour {

	private float _activeTimer;
	public float _maxActiveTimer = 6.0f;

	// Use this for initialization
	void Start () {
		_activeTimer = _maxActiveTimer;
	}
	
	// Update is called once per frame
	void Update () {
		_activeTimer -= Time.deltaTime;
		
		if(_activeTimer <= 0) {
			this.gameObject.SetActive(false);
			_activeTimer = _maxActiveTimer;
		}
	}
}
