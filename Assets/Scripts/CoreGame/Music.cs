using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    [SerializeField]
    AudioSource audioSource;
    float currentMusicTime;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        currentMusicTime = audioSource.time;
	}

    private void OnLevelWasLoaded(int level) {
        audioSource.time = currentMusicTime;
    }
}
