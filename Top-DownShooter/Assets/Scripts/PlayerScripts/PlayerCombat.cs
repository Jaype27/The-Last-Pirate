using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour {

	private int _goldPoints;
	public Text _goldAmountText;
	public AudioSource[] _soundEffect;
	private RightCannon _RCannon;
	private ForwardCannon _FCannon;
	private BackCannon _BCannon;
	// private GrapeShot _grapeShot;
	// public float _maxAbilityDuration;
	// private float _abilityDuration;
	// public Image _durationBar;
	// private bool _isGrapeShot = false;


	// Use this for initialization
	void Start () {
		// _abilityDuration = _maxAbilityDuration;
		// _grapeShot = GetComponent<GrapeShot>();
		_RCannon = GetComponent<RightCannon>();
		_FCannon = GetComponent<ForwardCannon>();
		_BCannon = GetComponent<BackCannon>();
	}
	
	// Update is called once per frame
	void Update () {
		GoldCount();
		AbilityUnlocked();
		/* DurationBar();
		if (_isGrapeShot == true) {
			GrapeShotAbility();
		} */
	}

	public void GoldTaken(int _amnt) {
		_goldPoints += _amnt;
	}

	void GoldCount() {
		_goldAmountText.text = "Gold: " + _goldPoints;
	}

	void AbilityUnlocked() {
		if(_goldPoints >= 10) {
			_RCannon.enabled = true;
		}

		if(_goldPoints >= 20) {
			_FCannon.enabled = true;
		}

		if(_goldPoints >= 30) {
			_BCannon.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "Gold") {
			_soundEffect[3].Play();
		}

		if(other.gameObject.tag == "Health") {
			_soundEffect[3].Play();
		}

		/* if(other.gameObject.tag == "GrapeShot") {
			_soundEffect[4].Play();
			_abilityDuration = _maxAbilityDuration;
			other.gameObject.SetActive(false);
			_isGrapeShot = true;
		} */
	}

	/* void GrapeShotAbility() {
		if(_abilityDuration > 0) {
			_abilityDuration -= Time.deltaTime;
			_grapeShot.enabled = true;
		}

		if(_abilityDuration <= 0) {
			_grapeShot.enabled = false;
			_isGrapeShot = false;
			_abilityDuration = _maxAbilityDuration;
		}
	}
	
	void DurationBar() {
		_durationBar.fillAmount = _abilityDuration / _maxAbilityDuration;
	} */
}
