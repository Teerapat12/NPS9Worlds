using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCheckPoint : MonoBehaviour {

	private bool hasPass = false;
	public string checkingTagName = "Nelle"; 
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == checkingTagName && !hasPass) {
			hasPass = true;
			gameController.passObjective ();
		}
	}
}
