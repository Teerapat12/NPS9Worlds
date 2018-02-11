using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NallePush : MonoBehaviour {

	public int beforePushMass = 300;
	public int whilePushMass = 40;

	private AudioSource audio;

	private Rigidbody2D thisRigidbody2D;

	// Use this for initialization
	void Start () {
		//Set itself mass to 300.
		thisRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		thisRigidbody2D.mass = beforePushMass;

		//Audio
		audio = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//If nelle is the one who is pushing, reduce mass to 5?

	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Nalle" && thisRigidbody2D.mass!=whilePushMass) {
			Debug.Log ("Nalle is pushing!!!");
			thisRigidbody2D.mass = whilePushMass;
			if(!audio.isPlaying)
				audio.Play();
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Nalle") {
			thisRigidbody2D.mass = beforePushMass;
			audio.Stop ();
			Debug.Log ("Nalle stop pushing");
		}
	}


}
