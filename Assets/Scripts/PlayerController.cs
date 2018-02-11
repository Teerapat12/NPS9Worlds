using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int currentPlayer = 0;
	private float cdFintimeStamp;
	private Camera mainCamera;	

	public GameObject[] characters;
	public float coolDownInSec = 0.00f;

	public Sprite NelleActiveIcon;
	public Sprite NelleInactiveIcon;

	public Sprite PoroActiveIcon;
	public Sprite PoroInactiveIcon;

	public Sprite SlowActiveIcon;
	public Sprite SlowInactiveIcon;

	private GameObject NalleIconRenderer, PoroIconRenderer, SlowIconRenderer;


	//TODO: Follow the player functionality
	//GameOver
	//Push Object. (Poro can also pull the object because he has hand.)

	// Use this for initialization
	void Start () {
		characters[0].GetComponent<PlatformController>().setActive();
		cdFintimeStamp = Time.time;
		NalleIconRenderer = GameObject.Find ("NalleButton");
		PoroIconRenderer = GameObject.Find ("PoroButton");
		SlowIconRenderer = GameObject.Find ("SlowButton");

		mainCamera = Camera.main;

		SwitchCharacter (currentPlayer);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SwitchCharacter(int i){
		Debug.Log (i);
		if(cdFintimeStamp<= Time.time){
			characters[currentPlayer].GetComponent<PlatformController>().setInactive();

			//Swap currentCharacter position with newCharacter position.
			Vector3 currentCharacterPosition = characters [currentPlayer].transform.position;
			characters [currentPlayer].transform.position = characters [i].transform.position;
			characters [i].transform.position = currentCharacterPosition;

			currentPlayer = i;

			characters[currentPlayer].GetComponent<PlatformController>().setActive();


			//Change camera target
			mainCamera.GetComponent<StrictCameraToScene>().target = characters[i].transform;

			setActiveIcon (i);

			cdFintimeStamp = Time.time + coolDownInSec;
		}
		else
			Debug.Log (cdFintimeStamp-Time.time);
	}

	//Seperate into three function incase we want some specific feature for each character.

	public void SwitchToNelle(){
		SwitchCharacter (0);
	}

	public void SwitchToPoro(){
		SwitchCharacter (1);
	}

	public void SwitchToSlow(){
		SwitchCharacter (2);
	}

	public void setActiveIcon(int character){
		if (character == 0) {
			if(NalleIconRenderer!=null) NalleIconRenderer.GetComponent<Image> ().sprite = NelleActiveIcon;
			if(PoroIconRenderer!=null) PoroIconRenderer.GetComponent<Image> ().sprite = PoroInactiveIcon;
			if(SlowIconRenderer!=null) SlowIconRenderer.GetComponent<Image> ().sprite = SlowInactiveIcon;
		}
		if (character == 1) {
			if(NalleIconRenderer!=null) NalleIconRenderer.GetComponent<Image> ().sprite = NelleInactiveIcon;
			if(PoroIconRenderer!=null) PoroIconRenderer.GetComponent<Image> ().sprite = PoroActiveIcon;
			if(SlowIconRenderer!=null) SlowIconRenderer.GetComponent<Image> ().sprite = SlowInactiveIcon;
		}
		if (character == 2) {
			if(NalleIconRenderer!=null) NalleIconRenderer.GetComponent<Image> ().sprite = NelleInactiveIcon;
			if(PoroIconRenderer!=null) PoroIconRenderer.GetComponent<Image> ().sprite = PoroInactiveIcon;
			if(SlowIconRenderer!=null) SlowIconRenderer.GetComponent<Image> ().sprite = SlowActiveIcon;
		}
	}

}
