using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	[SerializeField] float jumpPower;
	[SerializeField] AudioClip jumpSound;
	[SerializeField] AudioClip hitSound;
	[SerializeField] float slowSpeedRotation;
	[SerializeField] float rotationDown;
	[SerializeField] AudioClip pointSound;

	Rigidbody2D myRiggidBody;
	AudioSource[] myAudioSources;
	Animator myAnimator;

	// class GameOverSplash;
	GameOverSplash splashScript;

	bool isJump = false;
	bool isFall = false;

	void Awake(){
		myRiggidBody = GetComponent<Rigidbody2D> ();
		myAudioSources = GetComponents<AudioSource> ();
		myAnimator = GetComponent<Animator> ();

		splashScript = GetComponent<GameOverSplash> ();

		myRiggidBody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	void Update(){
		if (Application.platform == RuntimePlatform.Android) {
			foreach (Touch touch in Input.GetTouch) {
				if (touch.fingerId == 0) {
					if (!GameManager.instance.isPlaying) {
						GameUIManager.instance.showStartGameCanvas (false);
						GameManager.instance.isPlaying = true;

						myRiggidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
					}
					isJump = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Space) && !GameManager.instance.gameOver) {
			if (!GameManager.instance.isPlaying) {
				GameUIManager.instance.showStartGameCanvas (false);
				GameManager.instance.isPlaying = true;

				myRiggidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
			}
			isJump = true;
		}
	}

	void FixedUpdate(){
		if (GameManager.instance.isPlaying == false) {
			return;
		}

		if (isFall) {
			return;
		}

		ChangeRotation ();

		if (isJump) {
			Jump ();
			isJump = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (GameManager.instance.gameOver) {
			return;
		}
		// kalo numbur pipa
		else if (col.CompareTag ("Pipe")) {
			GameManager.instance.gameOver = true;
			PlaySound (hitSound, 0);
			splashScript.SplashIt ();
		}
		else if (col.CompareTag("Point")){
			GameManager.instance.point++;
			PlaySound (pointSound,1 );
			PointManger.instance.UpdateScore ();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ground")) { // jika sudah menyentuh box colidor background/tahan
			if (!GameManager.instance.gameOver) { // jika kondisi langsung nambrak tanah
				GameManager.instance.gameOver = true;
				PlaySound (hitSound, 0);
				splashScript.SplashIt ();
			}
			GameUIManager.instance.showGameOver(true);
			isFall = true;
		}
	}


	void Jump(){
		Vector3 velocity = myRiggidBody.velocity;
		velocity.y = jumpPower;
		myRiggidBody.velocity = velocity;
		PlaySound (jumpSound, 0);

		myAnimator.SetTrigger ("Fly");
	}

	void PlaySound(AudioClip sound, int _audioSourceID){
		myAudioSources [_audioSourceID].clip = sound;
		myAudioSources [_audioSourceID].Play ();
	}

	void ChangeRotation(){
		myRiggidBody.transform.rotation = Quaternion.Euler (Vector3.Lerp (Vector3.forward * -90f, Vector3.forward * 25f, (myRiggidBody.velocity.y - (rotationDown + 1) + slowSpeedRotation) / slowSpeedRotation));
	}
		
}
