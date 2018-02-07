using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	private bool isClosing = true;
	private Rigidbody2D rigidbody2D;

	public GameObject doorMaxPosObj;
	public GameObject doorMinPosObj;


	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		closeDoor ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (isClosing);
		if (isClosing) {
			//Check if door bottom position is at doorMinPos or not.
			if (this.transform.position.y - (this.transform.localScale.y / 2) <= doorMinPosObj.transform.position.y) {
				rigidbody2D.velocity = new Vector2 (0, 0);
			}
		} else {
			if (this.transform.position.y - (this.transform.localScale.y / 2) >= doorMaxPosObj.transform.position.y) {
				rigidbody2D.velocity = new Vector2 (0, 0);
			}
		}
	}

	public void openDoor(){
		isClosing = false;
		rigidbody2D.velocity = new Vector2(0,3f);

	}

	public void closeDoor(){
		isClosing = true;
		rigidbody2D.velocity = new Vector2(0,-3f);

	}
}
