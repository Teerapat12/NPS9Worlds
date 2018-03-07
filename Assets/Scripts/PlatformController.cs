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

	//AudioClips.
	private AudioSource audioSource;
	private AudioSource cameraSource;
	public AudioClip jumpSound;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource> ();
		cameraSource = Camera.main.GetComponent<AudioSource> ();
	}

	public void secondJump(){
		jump = true;
	}

	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		#if UNITY_STANDALONE || UNITY_WEBPLAYER //|| UNITY_ANDROID //Comment here

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

	public void walkingSound(float speed){
		if (Mathf.Abs (speed) > 0.001) {
			if (!audioSource.isPlaying)
				audioSource.Play ();
		} else 
			audioSource.Stop ();
	}

	void FixedUpdate()
	{
		if(isCurrentCharacter){

			#if UNITY_STANDALONE || UNITY_WEBPLAYER //|| UNITY_ANDROID //Comment here
			float h = Input.GetAxis("Horizontal");
			#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			float h = CrossPlatformInputManager.GetAxis("Horizontal");

			#endif

			walkingSound (h);


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

				// Add jump sound
				cameraSource.PlayOneShot(jumpSound);
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

	public void hurt(){
		Debug.Log ("Damaged!!");
	}


}
