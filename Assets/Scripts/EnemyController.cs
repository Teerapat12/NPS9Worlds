using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float pushPowerX = 50000f;
	public float pushPowerY = 200f;

	public AudioClip onDamageEnemySound;
	private AudioSource audioSource;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		audioSource = Camera.main.GetComponent<AudioSource> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Nalle" || coll.gameObject.tag == "Poro" || coll.gameObject.tag == "Slow") {
			audioSource.PlayOneShot (onDamageEnemySound);
			//Call that character gameObject.hurt()
			coll.gameObject.GetComponent<PlatformController>().hurt();
			//Bounce character of the enemy.
			Rigidbody2D rigidbody = coll.gameObject.GetComponent<Rigidbody2D>();
			rigidbody.AddForce(new Vector2(-Mathf.Sign(rigidbody.velocity.x)*pushPowerX,pushPowerY));

		}
	}

	public void Die(){
		gameController.passObjective ();
		Destroy(gameObject);
	}
}
