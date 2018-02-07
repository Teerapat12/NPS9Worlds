using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	private bool paused = false;
	public GameObject pauseUI;
	public GameObject controllerUI;

	public GameObject wallToGoal;
	public GameObject arrowUI;

	public GameObject fadeInOutPanel;

	public string nextSceneName;

	public int taskNumber = 5;

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

	public void passObjective(){
		Debug.Log ("Pass!");
		taskNumber -= 1;
		Debug.Log (taskNumber + " task left.");
		if (taskNumber == 0) {
			onPassStage ();
		}
	}

	public void onPassStage(){
		//Enable the portal that go to next stage
		Destroy(wallToGoal);
		//Arrow appear.
		arrowUI.SetActive(true);
	}


	public void goToNextStage(){
		// SCREEN FADE HERE
		StartCoroutine(FadeOut());
	}


	IEnumerator FadeOut(){
		fadeInOutPanel.GetComponent<Animator> ().Play ("PanelFadeOut");
		yield return new WaitForSeconds (1f);

		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
		{
			SceneManager.LoadScene(nextSceneIndex);
		}
		else
			Debug.Log ("Last stage cleared! Congratz");
	}
}
