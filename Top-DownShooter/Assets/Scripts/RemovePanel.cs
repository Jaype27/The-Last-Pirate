using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePanel : MonoBehaviour {

	public GameObject _removeMenu;

	public void BackButton() {
		_removeMenu.SetActive(false);
	}
}
