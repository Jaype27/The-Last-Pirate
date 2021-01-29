using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShoot : MonoBehaviour {
	public Transform _firePoint;
	public GameObject _mortarShellPrefab;
	public float _offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float _angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, _angle + _offset);
		
		if(Input.GetKey(KeyCode.Space)) {
				Instantiate(_mortarShellPrefab, _firePoint.position, _firePoint.rotation);
			}
	}

	void FixedUpdate() {
		
		

		
	}
}
