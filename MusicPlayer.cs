using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] songs;

	private AudioSource audioSource;
	private int index;
	private static MusicPlayer musicPlayer;
	// Use this for initialization
	void Awake () {

		if(musicPlayer == null)
		{
			musicPlayer = this;
		}
		else if(musicPlayer != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		audioSource = GetComponent<AudioSource>();

	}

	private void Start()
	{
		index = Random.Range(0, songs.Length);
		StartMusicPlayer();
	}

	void StartMusicPlayer()
	{
		audioSource.clip = songs[index];
		index++;
		if(index >= songs.Length)
		{
			index = 0;
		}

		audioSource.Play();
		Invoke("StartMusicPlayer", audioSource.clip.length + 0.5f);
	}
}
