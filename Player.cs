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
	public GameObject bullet;
	public Transform[] shotSpawns;
	public float fireRate;
	public int fireLevel = 1;

	private Rigidbody2D rb;
	private float nextFire;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

		if (CrossPlatformInputManager.GetButton("Fire") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			if(fireLevel >= 1)
			{
				Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
			}
			if(fireLevel >= 2)
			{
				Instantiate(bullet, shotSpawns[1].position, shotSpawns[1].rotation);
				Instantiate(bullet, shotSpawns[2].position, shotSpawns[2].rotation);
			}
			if(fireLevel >= 3)
			{
				Instantiate(bullet, shotSpawns[3].position, shotSpawns[3].rotation);
				Instantiate(bullet, shotSpawns[4].position, shotSpawns[4].rotation);
			}
			
		}

	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		rb.velocity = movement * speed;

		rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}
}
