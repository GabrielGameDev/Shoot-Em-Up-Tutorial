using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Text pointsText;
	public Slider slider;
	public GameObject loadingPanel;

	private AsyncOperation async = null;

	// Use this for initialization
	void Start () {

		SetPointsText(GameManager.gameManager.points);

	}
	
	// Update is called once per frame
	void Update () {

		if (async == null)
			return;

		slider.value = async.progress;

	}

	public void LoadGame()
	{
		loadingPanel.SetActive(true);
		StartCoroutine(Loading());
		

		
	}

	public void SetPointsText(int points)
	{
		pointsText.text = points.ToString();
	}

	IEnumerator Loading()
	{
		async = SceneManager.LoadSceneAsync("Game");
		yield return async;
	}
}
