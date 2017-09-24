using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject[] obstacles;
	public List<GameObject> obstaclesToSpawn = new List<GameObject> ();


    public float minTimeForObstacletoSpawn = 1.5f;
    public float maxTimeForObstacletoSpawn = 4.5f;

	int index;
    private Rigidbody2D myRB; 

	void Awake() {
		InitObstacles ();
      
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnRandomObstacle ());
	}



    void InitObstacles() {
		index = 0;
		// Initialisiere die Hindernisse
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], transform.position, Quaternion.identity);
			obstaclesToSpawn.Add (obj);
			obstaclesToSpawn [i].SetActive (false);
			index++;

			if (index == obstacles.Length) {
				index = 0;
			}
		}
	}

	IEnumerator SpawnRandomObstacle() {
		// Warte eine gewisse Zeit
		yield return new WaitForSeconds (Random.Range (minTimeForObstacletoSpawn, maxTimeForObstacletoSpawn));
		// Aktiviere Hindernisse
		int index = Random.Range(0, obstaclesToSpawn.Count);

		while (true) {
			if (!obstaclesToSpawn [index].activeInHierarchy) {
				obstaclesToSpawn [index].SetActive (true);
				obstaclesToSpawn [index].transform.position = transform.position;
				break;
			} else {
				index = Random.Range (0, obstaclesToSpawn.Count);
			}
		}

		StartCoroutine (SpawnRandomObstacle ());
	}
}
