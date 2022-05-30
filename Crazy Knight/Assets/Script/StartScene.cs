
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject btn;
    float timer = 5f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0){
            btn.SetActive(true);
        }
    }
}
