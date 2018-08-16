using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

	public static GameUIManager instance;
	[SerializeField] Animator gameOverAnim;
	[SerializeField] Animator startGameAnim;

	public void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		showStartGameCanvas (true);
	}

	public void showGameOver(bool _show){
		gameOverAnim.SetBool ("Show", _show);
	}

	public void showStartGameCanvas(bool _show){
		startGameAnim.SetBool ("Show", _show);
	}
}
