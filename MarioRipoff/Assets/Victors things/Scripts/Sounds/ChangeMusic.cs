using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeMusic : MonoBehaviour {
    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip sadMusic;


    private AudioSource source;

    void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    
    void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void Awake() {
        source = GetComponent<AudioSource>();

    }


    // Sets music depending on what levle was loaded.
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 1) {
            source.clip = level1Music;
            source.Play();
        }
        if (scene.buildIndex == 2) {
            source.clip = level2Music;
            source.Play();
        }
            
    }
}
