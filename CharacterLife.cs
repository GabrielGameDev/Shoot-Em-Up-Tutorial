using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : MonoBehaviour {

	public int health;
	public GameObject explosion;
	public Color damageColor;

	private bool isDead = false;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer>();

	}
	
	public void TakeDamage(int damage)
	{
		if (!isDead)
		{
			health -= damage;
			if(health <= 0)
			{
				Instantiate(explosion, transform.position, transform.rotation);
				if(this.GetComponent<Player>() != null)
				{

				}
				else
				{
					isDead = true;
					Destroy(gameObject);
				}
			}
			else
			{
				StartCoroutine(TakingDamage());
			}
		}
	}

	IEnumerator TakingDamage()
	{
		sprite.color = damageColor;
		yield return new WaitForSeconds(0.1f);
		sprite.color = Color.white;
	}
}
