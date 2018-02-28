using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour {



	public float speed = 0.001f;
	public int Direction = 1;

	public float fMinX = -2f;
	public float fMaxX = 2f;

	float enemyX;
	float originEnemyX;
	float difEnemyX;


	// Use this for initialization
	void Start () {
		originEnemyX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemyX = this.transform.position.x;
		difEnemyX = enemyX - originEnemyX;
		switch( Direction )
		{
		case 1:
			// Moving Left
			if( difEnemyX <fMaxX )
			{
				this.transform.position = new Vector2(this.transform.position.x+speed,this.transform.position.y);
			}
			else
			{
				// Hit left boundary, change direction
				Direction = -1;
				this.transform.localScale = new Vector2(this.transform.localScale.x*-1,this.transform.localScale.y);
			}
			break;

		case -1:
			// Moving Right
			if( difEnemyX > fMinX )
			{
				this.transform.position = new Vector2(this.transform.position.x-speed,this.transform.position.y);
			}
			else
			{
				// Hit right boundary, change direction
				Direction = 1;
				this.transform.localScale = new Vector2(this.transform.localScale.x*-1,this.transform.localScale.y);
			}
			break;
		}
	}
}
