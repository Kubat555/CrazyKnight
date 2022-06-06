using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button level2;
    int levelComplete;

    private void Start() {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2.interactable = false;

        switch (levelComplete)
        {
            case 2 :
                level2.interactable = true;
                break;
            case 3:
                level2.interactable = true;
                break;
        }
    }
    

    public void QuitGame(){
        Application.Quit();
    }
}
