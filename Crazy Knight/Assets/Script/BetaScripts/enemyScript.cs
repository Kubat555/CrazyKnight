using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int liveCount = 5;
    public Transform checkPoint;
    [SerializeField] private AudioSource pain;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(liveCount < 1){
                transform.position = checkPoint.position;
                liveCount = 5;
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy") && !enemyController.isAttack){
            pain.Play();
            liveCount -=1;
        }

        if(other.CompareTag("EndPoint")){
            liveCount = 5;
            SceneManager.LoadScene("scene1");
        }
    }
}
