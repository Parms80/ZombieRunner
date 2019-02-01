using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public Transform playerSpawnPoints;
	public GameObject landingAreaPrefab;
	private bool respawn = false;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;

	// Use this for initialization
	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
	}
		
	// Update is called once per frame
	void Update () {
		if (lastRespawnToggle != respawn) {
			Respawn ();
			respawn = false;
		} else {
			lastRespawnToggle = respawn;
		}
	}

	void Respawn() {
		int i = Random.Range (1, spawnPoints.Length);
		transform.position = spawnPoints [i].transform.position;
	}

	void OnFindClearArea() {
		Invoke ("DropFlare", 3f);
	}

	void DropFlare() {
		Instantiate (landingAreaPrefab, transform.position, transform.rotation);
	}
}
