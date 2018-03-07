using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SecondJump : MonoBehaviour {

	private bool onLedge = false;
	public Transform ledgeCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		onLedge = Physics2D.Linecast(transform.position, ledgeCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		#if UNITY_STANDALONE || UNITY_WEBPLAYER  //|| UNITY_ANDROID //Comment here

		if (Input.GetButtonDown("Jump") && onLedge)
		{
			GetComponent<PlatformController>().secondJump();
		}
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if (CrossPlatformInputManager.GetButtonDown("Jump") && onLedge)
		{
			GetComponent<PlatformController>().secondJump();
		}

		#endif
	}
}
