using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagicBoxButton : MonoBehaviour {

	public Transform spawnPosition;
	public GameObject magicBoxPrefab;

	private bool spawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (!spawned && coll.gameObject.name=="MagicBook") {
			Debug.Log ("Box Appear!");
			GameObject box = (GameObject)Instantiate (magicBoxPrefab, spawnPosition.position, spawnPosition.rotation);
			spawned = true;
		}

//		if (coll.gameObject.tag == "Nalle" && thisRigidbody2D.mass!=whilePushMass) {
//			//			Debug.Log ("Nalle is pushing!!!");
//			thisRigidbody2D.mass = whilePushMass;
//			if(!audio.isPlaying)
//				audio.Play();
//		}
	}


}
