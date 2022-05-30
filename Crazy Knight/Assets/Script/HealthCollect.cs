using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    public AudioClip collectedClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth) // здесь мы испозьзуем свойство health чтобы получить значение currentHealth в controller
            {
                controller.HealthUp(1);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }
        }
    }
}
