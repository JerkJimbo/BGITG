using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionEnemy : MonoBehaviour
{
    public int DamagePlayer;
    public int enemyDamage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Столкновение с врагом
        HealthScript enemy = collision.gameObject.GetComponent<HealthScript>();
        Debug.Log(enemy);
        if (enemy != null)
        {
            // Смерть врага
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            Debug.Log("Hello");
            if (enemyHealth != null) enemyHealth.Damage(enemyDamage);

            damagePlayer = true;
        }

        // Повреждения у игрока
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(DamagePlayer);
        }
    }

}