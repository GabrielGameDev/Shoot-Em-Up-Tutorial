using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerspawn : MonoBehaviour {

	public GameObject[] players;

	// Use this for initialization
	void Start () {

		Instantiate(players[GameManager.gameManager.characterIndex], transform.position, Quaternion.identity);

	}
	
	
}
