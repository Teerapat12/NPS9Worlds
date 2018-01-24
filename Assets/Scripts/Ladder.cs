using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	float speed = 6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay2D(Collider2D other){
		if(other.tag=="Nelle" &&Input.GetKey(KeyCode.W)){
			Debug.Log("going up");
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
		}
		else if(other.tag=="Nelle" &&Input.GetKey(KeyCode.S)){
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
		}
		else if(other.tag=="Nelle")
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}
}
