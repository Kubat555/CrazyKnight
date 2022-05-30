using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene("scene1");
    }

    public void Resume(){
        SceneManager.LoadScene("Resume");
    }

    public void GoMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame(){
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
