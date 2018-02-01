using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnStepped : MonoBehaviour {

	public float bounceForce = 20f;

	public AudioClip onSteppedSound;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = Camera.main.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Check if character
		if (coll.gameObject.tag == "Nelle" || coll.gameObject.tag=="Poro" || coll.gameObject.tag=="Slow")
			//Add force to character upward a bit to hsve a mario like effect.
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceForce));
			//Play onSteppedSound on AudioSource on camera. (So that we dont have to worry about htis object being delete)
			audioSource.PlayOneShot(onSteppedSound);
			//Die here. Call the overall enemy rather than the head.
			GetComponentInParent<EnemyController> ().Die();
			
	}
		
}
