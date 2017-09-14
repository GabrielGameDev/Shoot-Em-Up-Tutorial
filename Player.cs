using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

		

	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		rb.velocity = movement * speed;

		rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}
}
