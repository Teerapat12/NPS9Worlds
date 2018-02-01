using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrictCameraToScene : MonoBehaviour {

	public float dampTime = 0.25f;
	private Vector3 velocity = Vector3.zero;
	private Camera camera;
	public Transform target;

	public bool bounds;

	public GameObject minCameraPosObj;
	public GameObject maxCameraPosObj;

	private Vector3 minCameraPos;
	private Vector3 maxCameraPos;


	// Use this for initialization
	void Start () {
		setMinMaxPos ();
	}

	void setMinMaxPos(){
		camera = Camera.main;
		minCameraPos = minCameraPosObj.transform.position; //With more formula
		maxCameraPos = maxCameraPosObj.transform.position;

		float vertExtent = Camera.main.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;

		minCameraPos.x = minCameraPos.x + horzExtent;
		maxCameraPos.x = maxCameraPos.x - horzExtent;
		minCameraPos.y = minCameraPos.y + vertExtent;
		maxCameraPos.y = maxCameraPos.y - vertExtent;
	}
	
	// Update is called once per frame
	void Update () {
		setMinMaxPos ();
		if (target.position.x > 0)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.3f, 0.4f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		
			if (bounds) {
				transform.position = new Vector3 (
					Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
					Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
					transform.position.z
				);
			}

		}
	}

}
