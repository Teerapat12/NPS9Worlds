using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private bool paused = false;
	public Text pauseUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onPause(){
		Debug.Log (paused);
		if (!paused) {
			Time.timeScale = 0;
			pauseUI.text = "Paused";

			paused = true;
		} else {
			Time.timeScale = 1;
			pauseUI.text = "";

			paused = false;

		}
	}
}
