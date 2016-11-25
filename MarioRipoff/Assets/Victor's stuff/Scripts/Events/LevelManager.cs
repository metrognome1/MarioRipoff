using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    void OnEnable() {
        playerHealth.onDeath += restart;
        NextLevel.onDoorEnter += loadNextLevel;
    }

    void OnDisable() {
        playerHealth.onDeath -= restart;
        NextLevel.onDoorEnter -= loadNextLevel;
    }

    void restart() {
        Debug.Log("Entered Restart in level manager");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void loadNextLevel() {
        SceneManager.LoadScene("Level2");
    }
}