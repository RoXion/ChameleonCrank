using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControll : MonoBehaviour {

    public Image healthGui;

    public float health;
    private float maxHealth;
    private bool isDead;
    private bool isDamageable;

    // Use this for initialization
    void Start()
    {
        health = 30;
        maxHealth = 30;
        isDead = false;
        isDamageable = true;

        UpdateView();
    }

    void ApplyDamage(float damage)
    {
        if (isDamageable)
        {
            health -= damage;

            health = Mathf.Max(0, health);

            if (!isDead)
            {
                if (health == 0)
                {
                    isDead = true;
                }

                UpdateView();
                isDamageable = false;
                Invoke("ResetIsDamageable", 1);
            }
        }
    }

    void ResetIsDamageable()
    {
        isDamageable = true;
    }
    

    void UpdateView()
    {
        healthGui.fillAmount = health / maxHealth;
    }
}
