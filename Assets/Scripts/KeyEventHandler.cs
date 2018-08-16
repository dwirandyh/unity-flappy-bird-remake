using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyEventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// kalo teken r nanti load ulang scene
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
