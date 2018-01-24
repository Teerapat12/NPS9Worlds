using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool isCurrentCharacter = false;
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () 
	{

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Jump") && grounded && isCurrentCharacter)
		{
			jump = true;
		}
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if (CrossPlatformInputManager.GetButtonDown("Jump") && grounded && isCurrentCharacter)
		{
			jump = true;
		}

		#endif
	}

	void FixedUpdate()
	{
		if(isCurrentCharacter){

			#if UNITY_STANDALONE || UNITY_WEBPLAYER
			float h = Input.GetAxis("Horizontal");
			#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			float h = CrossPlatformInputManager.GetAxis("Horizontal");

			#endif


			anim.SetFloat("Speed", Mathf.Abs(h));

			if (h * rb2d.velocity.x < maxSpeed)
				rb2d.AddForce(Vector2.right * h * moveForce);

			if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
				rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

			if (h > 0 && !facingRight)
				Flip ();
			else if (h < 0 && facingRight)
				Flip ();

			if (jump)
			{
				anim.SetTrigger("Jump");
				rb2d.AddForce(new Vector2(0f, jumpForce));
				jump = false;
			}
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void setActive(){
		isCurrentCharacter = true;
	}

	public void setInactive(){
		isCurrentCharacter = false;
	}

	public bool isGrounded(){
		return grounded;
	}


}
