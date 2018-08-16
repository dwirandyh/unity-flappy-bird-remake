using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSplash : MonoBehaviour {

	[SerializeField] Image splashImage;
	[SerializeField] Color splashColor;
	[SerializeField] float fadeOutSpeed;

	public void SplashIt(){
		StartCoroutine (ISplashIt ());
	}

	IEnumerator ISplashIt(){
		float transition = 0f;

		while (transition < 1f) {
			splashImage.color = Color.Lerp (splashColor, Color.clear, transition);
			transition += Time.deltaTime * fadeOutSpeed;
			yield return null;
		}
	}
}
