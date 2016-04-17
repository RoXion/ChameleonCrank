using UnityEngine;
using System.Collections;

public class CollisonDamage : MonoBehaviour {

    public int damage = 1;


    void OnTriggerEnte2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            other.SendMessage("ApplyDamage", damage);
            
        }
    }
}
