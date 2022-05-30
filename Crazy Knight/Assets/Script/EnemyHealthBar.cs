using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    enemyController enemy;
    public HealthBar healthBar;
    void Start()
    {
        enemy = GetComponent<enemyController>();
        healthBar.SetMaxHealth(enemy.MaxHealth);
        healthBar.SetHealth(enemy.health);
    }

    private void Update()
    {
        healthBar.SetHealth(enemy.health);
    }
}
