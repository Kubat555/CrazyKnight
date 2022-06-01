using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameButtons;
    public GameObject endLevelUI;

    public AudioClip getHit;
    public AudioClip death;

    public Image saveEvent;

    public int maxHealth = 3;
    public float playerImmortalTime = 1f;
    public HealthBar healthBar;
    public int health { get { return currentHealth; } }

    AudioSource audioSourse;

    Transform spawnPosition;
    float immortalTime;
    bool playerImmortal = false;

    int currentHealth;
    Animator anim;

    PlayerMovement playerMove;
    PlayerCombat playerCombat;

    static public int kills = 0;

    int playerAttempt = 3; //Попытки героя возродится

    // Start is called before the first frame update
    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
        immortalTime = playerImmortalTime;
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerMove = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();

    }

    void Update()
    {
        if (playerImmortal)
        {
            immortalTime -= Time.deltaTime;
            if(immortalTime < 0)
            {
                playerImmortal = false;
                immortalTime = playerImmortalTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("SpawnPoint"))
        {
            spawnPosition = obj.transform;
            saveEvent.GetComponent<Animator>().SetTrigger("Save");
            obj.gameObject.SetActive(false);
        }
        if (obj.CompareTag("EndPoint"))
        {
            gameButtons.SetActive(false);
            endLevelUI.SetActive(true);
        }
        if (obj.CompareTag("Spikes"))
        {
            TakeDamage(maxHealth);
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.transform.CompareTag("Enemy"))
        {
            
            if (!playerImmortal)
            {
                TakeDamage(1);
            }
            
        }
    }

    void TakeDamage(int damage)
    {
        anim.SetTrigger("GetHit");

        currentHealth -= damage;
        playerImmortal = true;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            audioSourse.PlayOneShot(getHit);
        }
    }

    void Die()
    {
        anim.SetBool("IsDead", true);
        audioSourse.PlayOneShot(death);
        playerAttempt -= 1;
        if(playerMove != null)
        {
            playerMove.enabled = false;
        }
        if(playerCombat != null)
        {
            playerCombat.enabled = false;
        }
        Invoke("RespawnObj", 0.9f);
    }

    void RespawnObj()
    {
        if(playerAttempt <= 0)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            kills = 0;
            return;
        } 


        transform.position = spawnPosition.position;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        anim.SetBool("IsDead", false);

        if (playerMove != null)
        {
            playerMove.enabled = true;
        }
        if (playerCombat != null)
        {
            playerCombat.enabled = true;
        }
    }



    public void HealthUp(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSourse.PlayOneShot(clip);
    }
}
