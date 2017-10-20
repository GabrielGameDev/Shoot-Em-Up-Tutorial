using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

	public int characterIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	public void ChoosePlayer()
	{
		GameManager.gameManager.characterIndex = characterIndex;
		FindObjectOfType<Menu>().LoadGame();
	}
}
