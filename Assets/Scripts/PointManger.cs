using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManger : MonoBehaviour {

	public static PointManger instance;

	[SerializeField] Text poinText;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	public void UpdateScore(){
		poinText.text = GameManager.instance.point.ToString ();
	}
}
