using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroundSwitch : MonoBehaviour {


	public Transform doorPressed;
	public Transform doorNotPressed;

	public GameObject spriteRenderer;
	private DoorController doorController;

	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();

		doorController = GameObject.Find ("Door").GetComponent<DoorController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Nalle"||other.gameObject.tag == "Poro"||other.gameObject.tag == "Slow") {
			Debug.Log ("Open the door");
			collider.enabled = false;
			spriteRenderer.transform.position = doorPressed.transform.position;
			doorController.openDoor();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Nalle"||other.gameObject.tag == "Poro"||other.gameObject.tag == "Slow") {
			Debug.Log ("Close the door");
			collider.enabled = true;
			spriteRenderer.transform.position = doorNotPressed.transform.position;
			doorController.closeDoor();
		}
	}


}
