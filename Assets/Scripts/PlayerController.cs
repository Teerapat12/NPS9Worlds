using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private int currentPlayer = 0;
	private int numberOfCharacter = 3;
	private float cdFintimeStamp;

	public GameObject[] characters;
	public Camera mainCamera;
	public int coolDownInSec = 2;


	//TODO: Follow the player functionality
	//GameOver
	//Push Object. (Poro can also pull the object because he has hand.)

	// Use this for initialization
	void Start () {
		characters[0].GetComponent<PlatformController>().setActive();
		cdFintimeStamp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Switch")){
			SwitchCharacter();
		}
	}

	void SwitchCharacter(){
			if(cdFintimeStamp<= Time.time){
				characters[currentPlayer].GetComponent<PlatformController>().setInactive();

				currentPlayer+=1;
				//Implement switching delay (maybe 2 seconds)
				if(currentPlayer>=numberOfCharacter){
					currentPlayer = 0;
				}

				characters[currentPlayer].GetComponent<PlatformController>().setActive();
				//Change parent and reset local position
				mainCamera.transform.SetParent(characters[currentPlayer].transform);
				mainCamera.transform.localPosition = new Vector3(0,0,-10f);
				cdFintimeStamp = Time.time + coolDownInSec;
			}
	}
}
