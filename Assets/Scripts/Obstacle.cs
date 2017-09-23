using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = -3f;
	private Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		myRB.velocity = new Vector2 (speed, 0);
	}
}
