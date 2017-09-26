using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	public static LevelController levelController;

	public Text livesText;

	// Use this for initialization
	void Start () {

		levelController = this;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLivesText(int lives)
	{
		livesText.text = lives.ToString();
	}
}
