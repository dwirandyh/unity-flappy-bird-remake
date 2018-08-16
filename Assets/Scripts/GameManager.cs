using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[Header("Game Mechanic")]
	public float speed;
	public float maxPipeLength;
	public float minPipeLength;
	public bool gameOver = false;
	public bool isPlaying = false;

	[Header("Game State")]
	public int point;

	// singleton class
	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

}
