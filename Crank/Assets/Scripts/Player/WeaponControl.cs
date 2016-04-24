using UnityEngine;
using System.Collections;

public enum Weapons
{
    Blaster,
    Claws
}

public class WeaponControl : MonoBehaviour
{

    private Weapons activeWeapon;
    private bool isAttacking;
    private bool isCharging;

    public float chargeLevel;
    private int chargeSpeed;
    private int clawPower;

    public Transform weaponsporn;

    public GameObject blaster1;
    public GameObject blaster2;
    public GameObject blaster3;

    void Start()
    {
        isAttacking = false;
        isCharging = false;
        activeWeapon = Weapons.Blaster;
        chargeLevel = 0;
        chargeSpeed = 1;
    }

    void FixedUpdate()
    {
        if ((Input.GetButtonDown("Fire1") && !isAttacking) || isCharging)
        {
            isAttacking = true;

            switch (activeWeapon)
            {
                case Weapons.Blaster:
                        Blaster();
                    break;
                case Weapons.Claws:
                    break;
                default:
                    break;
            }
        }
    }

    void Blaster()
    {
        isCharging = true;
        

        if (isCharging && Input.GetButton("Fire1"))
        {
            chargeLevel += Time.deltaTime * chargeSpeed;

            chargeLevel = Mathf.Clamp(chargeLevel, 0, 2);
        }

        if (Input.GetButtonUp("Fire1"))
        {

            GameObject laser;

            if (chargeLevel < 1)
            {
                laser = (GameObject)Instantiate(blaster1, weaponsporn.position, Quaternion.identity);
            }
            else if (chargeLevel >= 1 && chargeLevel < 2)
            {
                laser = (GameObject)Instantiate(blaster2, weaponsporn.position, Quaternion.identity);
            }
            else
            {
                laser = (GameObject)Instantiate(blaster3, weaponsporn.position, Quaternion.identity);
            }

            laser.GetComponent<Blaster>().setDirection(gameObject.GetComponent<PlayerController>().isLookingRight);

            isCharging = false;
            isAttacking = false;
            chargeLevel = 0;
        }
    }
}
