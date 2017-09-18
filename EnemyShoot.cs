using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject bullet;
	public float fireRate;
	public Transform[] shotSpawns;

	// Use this for initialization
	void Start () {

		InvokeRepeating("Fire", fireRate, fireRate);

	}
	
	void Fire()
	{
		for (int i = 0; i < shotSpawns.Length; i++)
		{
			Instantiate(bullet, shotSpawns[i].position, shotSpawns[i].rotation);
		}
	}
}
