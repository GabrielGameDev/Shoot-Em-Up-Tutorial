using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : MonoBehaviour {

	public int health;
	public GameObject explosion;
	public Color damageColor;
	public int scorePoints;
	public GameObject[] dropItems;

	[HideInInspector]
	public bool isDead = false;
	
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
				isDead = true;
				if(explosion != null)
				Instantiate(explosion, transform.position, transform.rotation);
				if(this.GetComponent<Player>() != null)
				{
					GetComponent<Player>().Respawn();
				}
				else
				{
					chanceToDroptItem++;
					int random = Random.Range(0, 100);
					if(random < chanceToDroptItem && dropItems.Length > 0)
					{
						Instantiate(dropItems[Random.Range(0, dropItems.Length)], transform.position, Quaternion.identity);
						chanceToDroptItem = 0;
					}
					LevelController.levelController.SetScore(scorePoints);
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
