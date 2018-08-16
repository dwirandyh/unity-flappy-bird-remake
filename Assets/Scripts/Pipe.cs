using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	float cameraLeftBorder;
	float cameraRightBorder;
	float halfWidth;

	// Use this for initialization
	void Start () {
		// orthographicsize panjang dari tengah kamera ke atas dikurang di kali aspect ratio untuk mendapatkan jarak dari tengah kamera ke kiri/kanan
		cameraLeftBorder = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
		cameraRightBorder = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
		halfWidth = GetComponentInChildren<SpriteRenderer> ().bounds.size.x / 2f;
		transform.position = ((Vector3.right * transform.position.x) + (Vector3.up * Random.Range (GameManager.instance.minPipeLength, GameManager.instance.maxPipeLength)));
	}

	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.isPlaying) {
			return;
		}

		if (GameManager.instance.gameOver) {
			return;
		}

		// jika ground sudah tidak terlihat di kamera
		if (transform.position.x <= (cameraLeftBorder - halfWidth - 1)) {
			transform.position = ((Vector3.right * (cameraRightBorder + (halfWidth * 2f))) + (Vector3.up * Random.Range (GameManager.instance.minPipeLength, GameManager.instance.maxPipeLength)));
		}

		// gerakan ground ke kanan
		transform.Translate(Vector3.left * GameManager.instance.speed * Time.deltaTime);
	}
}
