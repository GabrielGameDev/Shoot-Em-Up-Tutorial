using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public enum ItemEffect
{
	shield, levelUp, special
}

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject bullet;
	public Transform[] shotSpawns;
	public float fireRate;
	public int fireLevel = 1;
	public int lives = 3;
	public float spawnTime;
	public float invencibilityTime;
	public GameObject specialLaser;
	public GameObject shield;
	public SpriteRenderer sprite;
	
	private Rigidbody2D rb;
	private float nextFire;
	private bool isDead = false;
	private Vector3 startPosition;
	private CharacterLife characterLife;
	private int special;

	// Use this for initialization
	void Start () {

		characterLife = GetComponent<CharacterLife>();
		
		rb = GetComponent<Rigidbody2D>();
		
		startPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead)
		{
			if (CrossPlatformInputManager.GetButton("Fire") && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				if (fireLevel >= 1)
				{
					Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
				}
				if (fireLevel >= 2)
				{
					Instantiate(bullet, shotSpawns[1].position, shotSpawns[1].rotation);
					Instantiate(bullet, shotSpawns[2].position, shotSpawns[2].rotation);
				}
				if (fireLevel >= 3)
				{
					Instantiate(bullet, shotSpawns[3].position, shotSpawns[3].rotation);
					Instantiate(bullet, shotSpawns[4].position, shotSpawns[4].rotation);
				}

			}
			
			if(CrossPlatformInputManager.GetButtonDown("Special") && special > 0)
			{
				Instantiate(specialLaser, transform);
				special--;
				LevelController.levelController.SetSpecial(special);
			}
		}
		

	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		rb.velocity = movement * speed;

		rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}

	public void Respawn()
	{
		lives--;
		if(lives > 0)
		{
			StartCoroutine(Spawning());
		}
		else
		{
			lives = 0;
			isDead = true;
			sprite.enabled = false;
			LevelController.levelController.GameOver();
		}

		LevelController.levelController.SetLivesText(lives);
	}

	IEnumerator Spawning()
	{
		isDead = true;
		sprite.enabled = false;
		fireLevel = 1;
		gameObject.layer = 11;
		yield return new WaitForSeconds(spawnTime);
		isDead = false;
		
		transform.position = startPosition;
		for (float i = 0; i < invencibilityTime; i+= 0.1f)
		{
			sprite.enabled = !sprite.enabled;
			yield return new WaitForSeconds(0.1f);
		}
		gameObject.layer = 8;
		sprite.enabled = true;
		characterLife.isDead = false;
	}
	
	public void SetItemEffect(ItemEffect effect)
	{
		if(effect == ItemEffect.levelUp)
		{
			fireLevel++;
			if (fireLevel >= 3)
				fireLevel = 3;
		}
		else if(effect == ItemEffect.special)
		{
			special++;
			LevelController.levelController.SetSpecial(special);
		}
		else if(effect == ItemEffect.shield)
		{
			Instantiate(shield, transform);
		}
	}
}
