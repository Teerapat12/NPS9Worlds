using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	private int currentPlayer = 0;
	private int numberOfCharacter = 3;
	private float cdFintimeStamp;

	public GameObject[] characters;
	public Camera mainCamera;	
	public float coolDownInSec = 0.00f;


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
		if (CrossPlatformInputManager.GetButtonDown ("SwitchNelle")) {
			SwitchCharacter (0);
		} else if (CrossPlatformInputManager.GetButtonDown ("SwitchPoro")) {
			SwitchCharacter (1);
		} else if (CrossPlatformInputManager.GetButtonDown ("SwitchSlow")) {
			SwitchCharacter (2);
		} 

	}

	void SwitchCharacter(){
		if (cdFintimeStamp <= Time.time) {
			characters [currentPlayer].GetComponent<PlatformController> ().setInactive ();

			currentPlayer += 1;
			//Implement switching delay (maybe 2 seconds)
			if (currentPlayer >= numberOfCharacter) {
				currentPlayer = 0;
			}

			characters [currentPlayer].GetComponent<PlatformController> ().setActive ();
			//Change parent and reset local position
			mainCamera.transform.SetParent (characters [currentPlayer].transform);
			mainCamera.transform.localPosition = new Vector3 (0, 0, -10f);
			cdFintimeStamp = Time.time + coolDownInSec;
		} else
			Debug.Log ("Cool down");
	}

	void SwitchCharacter(int i){
		Debug.Log (i);
		if(cdFintimeStamp<= Time.time){
			characters[currentPlayer].GetComponent<PlatformController>().setInactive();

			currentPlayer = i;

			characters[currentPlayer].GetComponent<PlatformController>().setActive();
			//Change parent and reset local position
			mainCamera.transform.SetParent(characters[currentPlayer].transform);
			mainCamera.transform.localPosition = new Vector3(0,0,-10f);
			cdFintimeStamp = Time.time + coolDownInSec;
		}
		else
			Debug.Log (cdFintimeStamp-Time.time);
	}

	//Seperate into three function incase we want some specific feature for each character.

	public void SwitchToNelle(){
		if(cdFintimeStamp<= Time.time){
			characters[currentPlayer].GetComponent<PlatformController>().setInactive();

			currentPlayer = 0;

			characters[currentPlayer].GetComponent<PlatformController>().setActive();
			//Change parent and reset local position
			mainCamera.transform.SetParent(characters[currentPlayer].transform);
			mainCamera.transform.localPosition = new Vector3(0,0,-10f);
			cdFintimeStamp = Time.time + coolDownInSec;
		}
		else
			Debug.Log (cdFintimeStamp-Time.time);
	}

	public void SwitchToPoro(){
		if(cdFintimeStamp<= Time.time){
			characters[currentPlayer].GetComponent<PlatformController>().setInactive();

			currentPlayer = 1;

			characters[currentPlayer].GetComponent<PlatformController>().setActive();
			//Change parent and reset local position
			mainCamera.transform.SetParent(characters[currentPlayer].transform);
			mainCamera.transform.localPosition = new Vector3(0,0,-10f);
			cdFintimeStamp = Time.time + coolDownInSec;
		}
		else
			Debug.Log (cdFintimeStamp-Time.time);
	}

	public void SwitchToSlow(){
		if(cdFintimeStamp<= Time.time){
			characters[currentPlayer].GetComponent<PlatformController>().setInactive();

			currentPlayer = 2;

			characters[currentPlayer].GetComponent<PlatformController>().setActive();
			//Change parent and reset local position
			mainCamera.transform.SetParent(characters[currentPlayer].transform);
			mainCamera.transform.localPosition = new Vector3(0,0,-10f);
			cdFintimeStamp = Time.time + coolDownInSec;
		}
		else
			Debug.Log (cdFintimeStamp-Time.time);
	}

}
