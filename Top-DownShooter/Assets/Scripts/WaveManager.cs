using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public static int _enemyRemain;

	[System.Serializable]
	public class Wave {

		public GameObject[] _enemyType;
		public int _enemyCount;
		public float _spawnRate;
	}

	public Wave[] _waves;
	public Transform _spawnPoint;
	public float _nextWaveTime; // store time between eaves
	public float _waveCountDown;
	private int _waveIndex;
	// public GameManager _GM;

	void Start() {
		_waveCountDown = _nextWaveTime;
	}

	void Update() {

		if(_enemyRemain > 0) {
			return;
		}

		if(_waveCountDown <= 0) {
			StartCoroutine(SpawnWave());
			_waveCountDown = _nextWaveTime;
			return;
		}  

			_waveCountDown -= Time.deltaTime;

	}

	IEnumerator SpawnWave () {

		Wave _wave = _waves[_waveIndex];

		_enemyRemain = _wave._enemyCount;

		for(int i = 0; i < _wave._enemyCount; i++) {
			SpawnEnemy(_wave._enemyType[Random.Range(0, _wave._enemyType.Length)]);
			yield return new WaitForSeconds(_wave._spawnRate);
		}
		
		_waveIndex++;

		if(_waveIndex == _waves.Length) {
			this.enabled = false;
		}
		
	}
	
	void SpawnEnemy(GameObject _enemy) {
		Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
		_enemyRemain++;


		// TODO: decrement _enemyRemain(--) on enemy health script;
	}
}
