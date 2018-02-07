using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroundSwitch : MonoBehaviour {

	public Sprite switchNotPressed;
	public Sprite switchPressed;
	private SpriteRenderer spriteRenderer;
	private DoorController doorController;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = switchNotPressed;

		doorController = GameObject.Find ("Door").GetComponent<DoorController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Nelle"||other.gameObject.tag == "Poro"||other.gameObject.tag == "Slow") {
			Debug.Log ("Open the door");
			spriteRenderer.sprite = switchPressed;
			doorController.openDoor();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Nelle"||other.gameObject.tag == "Poro"||other.gameObject.tag == "Slow") {
			Debug.Log ("Close the door");
			spriteRenderer.sprite = switchNotPressed;
			doorController.closeDoor();
		}
	}


}
