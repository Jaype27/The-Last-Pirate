using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<int> _enemyShips = new List<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			_enemyShips.Add(Random.Range(1, 100));
		}

		if(Input.GetKeyDown(KeyCode.Q)) {
			_enemyShips.Remove(_enemyShips[Random.Range(0, _enemyShips.Count)]);
		}
	}
}
