using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NellePush : MonoBehaviour {

	public int beforePushMass = 300;
	public int whilePushMass = 40;

	private Rigidbody2D thisRigidbody2D;

	// Use this for initialization
	void Start () {
		//Set itself mass to 300.
		thisRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		thisRigidbody2D.mass = beforePushMass;
	}
	
	// Update is called once per frame
	void Update () {
		//If nelle is the one who is pushing, reduce mass to 5?

	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Nelle" && thisRigidbody2D.mass!=whilePushMass) {
			Debug.Log ("Nelle is pushing!!!");
			thisRigidbody2D.mass = whilePushMass;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Nelle") {
			thisRigidbody2D.mass = beforePushMass;
			Debug.Log ("Nelle stop pushing");
		}
	}


}
