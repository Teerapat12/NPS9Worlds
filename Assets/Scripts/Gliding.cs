using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Gliding : MonoBehaviour {


	private PlatformController controller;
	private Rigidbody2D rb2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlatformController>();
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//If jumping and falling and holding jump
		if(!controller.isGrounded() && rb2d.velocity.y<0 && (Input.GetButton("Jump")||CrossPlatformInputManager.GetButton("Jump"))){
			//Gliding			
			anim.SetTrigger("Glide");
			rb2d.gravityScale = 0.05f;
		}
		else if(rb2d.gravityScale!=1f){
			rb2d.gravityScale = 1f;
		}
	}
}
