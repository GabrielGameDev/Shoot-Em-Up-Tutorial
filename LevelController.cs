using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public static LevelController levelController;

	public float startWait;
	public GameObject[] enemies;
	public Boundary boundary;
	public Vector2 spawnWait;
	public int enemyCountMax = 10;
	public float spawnWaitMin;
	public float waveWait;
	public float waveWaitMin;
	public GameObject gameOverText;

	public Text livesText;
	public Text scoreText;
	public Text recordText;
	public Text specialText;

	private bool gameOver = false;
	private int enemyCount = 1;
	private int score;

	// Use this for initialization
	void Start () {

		levelController = this;
		StartCoroutine(SpawnWaves());

	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOver)
		{
			if (Input.GetMouseButtonDown(0))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (!gameOver)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				GameObject enemy = enemies[Random.Range(0, enemies.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax), boundary.yMin, 0);
				Instantiate(enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(Random.Range(spawnWait.x, spawnWait.y));
			}

			enemyCount++;
			if (enemyCount >= enemyCountMax)
				enemyCount = enemyCountMax;
			spawnWait.x -= 0.1f;
			spawnWait.y -= 0.1f;
			if (spawnWait.y <= spawnWaitMin)
				spawnWait.y = spawnWaitMin;
			if (spawnWait.x <= spawnWaitMin)
				spawnWait.x = spawnWaitMin;
			yield return new WaitForSeconds(waveWait);
			waveWait -= 0.1f;
			if (waveWait <= waveWaitMin)
				waveWait = waveWaitMin;

		}
	}
	
	public void SetLivesText(int lives)
	{
		livesText.text = lives.ToString();
	}
	
	public void SetScore(int scorePoints)
	{
		score += scorePoints;
		scoreText.text = score.ToString();
	}
	
	public void GameOver()
	{
		gameOver = true;
		gameOverText.SetActive(true);

		if (PlayerPrefs.GetInt("MaxScore") < score)
			PlayerPrefs.SetInt("MaxScore", score);

		recordText.text = "Record: " + PlayerPrefs.GetInt("MaxScore");
	}
	
	public void SetSpecial(int value)
	{
		specialText.text = value.ToString();
	}
}
