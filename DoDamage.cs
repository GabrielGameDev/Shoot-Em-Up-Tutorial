using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour {

	public int damage = 1;
	
	public bool destroyByContact = true;
	public bool destroyShots = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		CharacterLife character = other.GetComponent<CharacterLife>();
		if(character != null)
		{
			character.TakeDamage(damage);
			if(destroyByContact)
			Destroy(gameObject);
		}
		
		DoDamage shot = other.GetComponent<DoDamage>();
		if(shot != null && destroyShots)
		{
			Destroy(other.gameObject);
		}
	}
}
