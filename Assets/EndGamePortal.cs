using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePortal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag=="Nalle"||other.gameObject.tag=="Poro"||other.gameObject.tag=="Slow")
			GameObject.Find ("GameController").GetComponent<GameController> ().goToNextStage ();
	}
}
