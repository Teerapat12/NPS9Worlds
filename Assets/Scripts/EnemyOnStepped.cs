using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnStepped : MonoBehaviour {

	public float bounceForce = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Check if character
		if (coll.gameObject.tag == "Nelle" || coll.gameObject.tag=="Poro" || coll.gameObject.tag=="Slow")
			//Add force to character upward a bit to hsve a mario like effect.
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceForce));
			//Die here. Call the overall enemy rather than the head.
			GetComponentInParent<EnemyController> ().Die();
			
	}
		
}
