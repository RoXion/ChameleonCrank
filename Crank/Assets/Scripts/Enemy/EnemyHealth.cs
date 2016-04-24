using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health;

    void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
