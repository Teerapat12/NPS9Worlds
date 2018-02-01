using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	private bool paused = false;
	public GameObject pauseUI;
	public GameObject controllerUI;

	// Use this for initialization
	void Start () {
		pauseUI.GetComponent<Canvas> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onPause(){
		if (!paused) {
			Time.timeScale = 0;
			enableCanvas (pauseUI);
			disableCanvas (controllerUI);
			paused = true;
		} else {
			onResume ();
		}
	}

	public void onResume(){
		Time.timeScale = 1;
		disableCanvas (pauseUI);
		enableCanvas (controllerUI);
		paused = false;
	}

	public void onRestart(){
		onResume ();
		Application.LoadLevel(Application.loadedLevel);
	}

	public void onExit(){
		Application.Quit ();
	}

	public void enableCanvas(GameObject obj){
		obj.GetComponent<Canvas> ().enabled = true;
	}

	public void disableCanvas(GameObject obj){
		obj.GetComponent<Canvas> ().enabled = false;
	}
}
