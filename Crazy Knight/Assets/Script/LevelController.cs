using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void isEndGame()
    {
        if (sceneIndex > PlayerPrefs.GetInt("LevelComplete"))
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
        Time.timeScale = 1f;
    }

}
