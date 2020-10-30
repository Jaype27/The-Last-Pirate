using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public static int _enemyRemain;

	[System.Serializable]
	public class Wave {

		public GameObject[] _enemyType;
		public int _enemyCount;
		public float _spawnRate;
	}

	public Wave[] _waves;
	public Transform[] _spawnPoint;
	public float _nextWaveTime; // store time between waves
	public float _waveCountDown;
	private int _waveIndex;
	public Text _waveText;
	public Text _noeText;
	public Text _countdownText;

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
			_countdownText.gameObject.SetActive(false);
			return;
		}  else {
			_countdownText.gameObject.SetActive(true);
		}
		
		_waveCountDown -= Time.deltaTime;
		_waveCountDown = Mathf.Clamp(_waveCountDown, 0f, Mathf.Infinity);
		_countdownText.text = string.Format("{0:00.00}", _waveCountDown);


	}

	IEnumerator SpawnWave () {

		Wave _wave = _waves[_waveIndex];		

		_waveIndex++;
		_waveText.text = "Wave: " + _waveIndex;

		for(int i = 0; i < _wave._enemyCount; i++) {
			SpawnEnemy(_wave._enemyType[Random.Range(0, _wave._enemyType.Length)]);
			yield return new WaitForSeconds(_wave._spawnRate);
			
		}
		
		if(_waveIndex == _waves.Length) {
			this.enabled = false;
		}
		
	}
	
	void SpawnEnemy(GameObject _enemy) {
		
		Instantiate(_enemy, _spawnPoint[Random.Range(0, _spawnPoint.Length)].position, _spawnPoint[Random.Range(0, _spawnPoint.Length)].rotation);
		_enemyRemain++;
		_noeText.text = "NOE: " + _enemyRemain;
		
	}
}
