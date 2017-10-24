using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public int characterIndex;
	public int shipCost;
	public string shipName;
	public Text shipCostText;

	private bool bought = true;
	// Use this for initialization
	void Start () {

		if (shipCost == 0)
			return;

		bought = PlayerPrefs.HasKey(shipName);

		if (!bought)
		{
			shipCostText.text = shipCost.ToString();
		}
		else
		{
			shipCostText.text = "";
		}

	}
	
	public void ChoosePlayer()
	{
		if (bought)
		{
			GameManager.gameManager.characterIndex = characterIndex;
			FindObjectOfType<Menu>().LoadGame();
		}
		else if(GameManager.gameManager.points >= shipCost)
		{
			PlayerPrefs.SetString(shipName, shipName);
			GameManager.gameManager.characterIndex = characterIndex;
			GameManager.gameManager.points -= shipCost;
			PlayerPrefs.SetInt("Points", GameManager.gameManager.points);
			FindObjectOfType<Menu>().SetPointsText(GameManager.gameManager.points);
			FindObjectOfType<Menu>().LoadGame();
			
		}
		
	}
}
