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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void loadNextLevel() {
        SceneManager.LoadScene("Level2");
    }
}