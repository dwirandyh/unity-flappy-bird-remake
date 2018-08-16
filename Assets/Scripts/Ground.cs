using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	float cameraLeftBorder;
	float halfWidth;

	// Use this for initialization
	void Start () {
		// orthographicsize panjang dari tengah kamera ke atas dikurang di kali aspect ratio untuk mendapatkan jarak dari tengah kamera ke kiri/kanan
		cameraLeftBorder = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
		halfWidth = GetComponent<SpriteRenderer> ().bounds.size.x / 2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.gameOver) {
			return;
		}

		// jika ground sudah tidak terlihat di kamera
		if (transform.position.x <= (cameraLeftBorder - halfWidth)) {
			transform.Translate(Vector3.right * ((halfWidth * 4f) - 0.1f));
		}

		// gerakan ground ke kanan
		transform.Translate(Vector3.left * GameManager.instance.speed * Time.deltaTime);
	}
}
