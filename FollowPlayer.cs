using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public float speed;

	private Transform player;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<Player>().transform;

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

	}
}
