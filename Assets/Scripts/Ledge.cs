using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var platform = transform.parent;

		GameObject nelle = GameObject.Find ("Slow");
		Debug.Log (nelle);
		Collider2D nalleCollider = nelle.GetComponent<Collider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D jumper) {
		//make the parent platform ignore the jumper
//		Debug.Log (gameObject.layer);
//		gameObject.layer = LayerMask.NameToLayer("ThroughGround");
//		Debug.Log (gameObject.layer);
		Physics2D.IgnoreCollision(jumper, gameObject.GetComponent<Collider2D>(),(jumper.GetComponent<Rigidbody2D>().velocity.y > 0.0f));
	}

//	void OnTriggerExit2D (Collider2D jumper) {
//		Debug.Log ("Exiting");
//	}
}
