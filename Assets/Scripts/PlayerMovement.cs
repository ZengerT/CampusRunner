using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float jumpForce = 5f;
	public float forwardForce = 0f;
    public float playerSpeed = 10f;

    public GameObject player;

    public AudioClip jumpSound; 



	private Rigidbody2D myRB;
	private bool canJump;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		myRB = GetComponent<Rigidbody2D> ();
	}

	// Jump Funktion
	public void Jump()
	{
		// Darf Spieler überhaupt springen?
		if (canJump) 
		{
			canJump = false;

			// Ist die Position des Spielers aktuell in der Mitte?
			if (transform.position.x < 0) 
			{
				// Spieler befindet sich aktuell nicht in der Mitte
				forwardForce = 2f;
			} else 
			{
				// Spieler ist in der Mitte
				forwardForce = 0f;
			}

			myRB.velocity = new Vector2 (forwardForce, jumpForce);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		canJump = true;
	}


    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            source.PlayOneShot(jumpSound, 1);
            Debug.Log("Jump");
        }

    }

   
}