using UnityEngine;
using System.Collections;

public class CollisonDamage : MonoBehaviour {

    public int damage = 1;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            other.SendMessage("ApplyDamage", damage);
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            other.SendMessage("ApplyDamage", damage);

        }
    }
}
