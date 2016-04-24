using UnityEngine;
using System.Collections;

public class Blaster : MonoBehaviour {

    public int damage;
    public int speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            other.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    public void setDirection(bool lookingRight)
    {
        
        if (lookingRight)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
        }
        else
        {
            Vector3 myScale = transform.localScale;
            myScale.x *= -1;
            transform.localScale = myScale;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
        }
    }
}
