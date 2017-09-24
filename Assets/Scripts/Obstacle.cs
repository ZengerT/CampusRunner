using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    public float speed;
    static public float speedMultiplier = 1f; 
	private Rigidbody2D myRB;
    private Scene scene; 




  // Use this for initialization
    void Start () {
		myRB = GetComponent<Rigidbody2D> ();

  

       
    }

    private void Update()
    {
        setSpeed();
    }

    // Update is called once per frame

    public void setSpeed()
    {

        {

            Scene scene = SceneManager.GetActiveScene();
            if (scene.name.Contains("FirstLevel"))
            {
                //Debug.Log("Loaded Level One, setting obstaclespeed");
                speed = -3f;
                myRB.velocity = new Vector2(speed* speedMultiplier, 0);

            }
            if (scene.name.Contains("SecondLevel"))
            {
                //Debug.Log("Loaded Level Two, setting obstaclespeed");
                // Debug.Log(scene.name);
                speed = -3.3f;
                myRB.velocity = new Vector2(speed * speedMultiplier, 0);

            }
            if (scene.name.Contains("ThirdLevel"))
            {
                //Debug.Log("Loaded Level Three, setting obstaclespeed");
                speed = -3.6f;
                myRB.velocity = new Vector2(speed * speedMultiplier, 0);

            }
            if (scene.name.Contains("FourthLevel"))
            {
                // Debug.Log("Loaded Level Four, setting obstaclespeed");
                speed = -3.9f;
                myRB.velocity = new Vector2(speed * speedMultiplier, 0);
            }
            if (scene.name.Contains("FifthLevel"))
            {
                // Debug.Log("Loaded Level Five, setting obstaclespeed");
                speed = -4.2f;
                myRB.velocity = new Vector2(speed * speedMultiplier, 0);
            }





        }


    }
}
