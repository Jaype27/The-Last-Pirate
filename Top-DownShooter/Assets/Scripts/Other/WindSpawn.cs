using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawn : MonoBehaviour {


	public int _minXValue;
	public int _maxXValue;
	public int _minYValue;
	public int _maxYValue;


	private Vector2 _minValue;
	private Vector2 _maxValue;
	private float _xAxis;
	private float _yAxis;
	private Vector2 _randomSpawn;
	private float _nextSpawnTimer;
	private float _maxSpawnTimer;
	PoolManager _poolMG;

	// Use this for initialization
	void Start () {
		_nextSpawnTimer = _maxSpawnTimer;
		
		_poolMG = PoolManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		_nextSpawnTimer -= Time.deltaTime;

		if(_nextSpawnTimer <= 0) { // Causes delay upon playing / Not a problem but something to look into
			SpawnWindLocation();
			_nextSpawnTimer = Random.Range(6, 10);
			
		}
	}

	void SpawnWindLocation() {
		_minValue = new Vector2(_minXValue, _minYValue);
		_maxValue = new Vector2(_maxXValue, _maxYValue);

		_xAxis = Random.Range(_minValue.x, _maxValue.x);
		_yAxis = Random.Range(_minValue.y, _maxValue.y);

		_randomSpawn = new Vector2(_xAxis, _yAxis);

		_poolMG.SpawnFromPool("windbox", _randomSpawn, Quaternion.identity);
	}
}
