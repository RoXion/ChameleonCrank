using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int maxSpeed;
    public int jumpForce;

    public LayerMask whatIsGround;
    public Transform groundDetector;

    private bool jump;
    private bool isGrounded;

    private Rigidbody2D rb2D;

    void Start () {
        maxSpeed = 5;
        jumpForce = 500;

        jump = false;
        isGrounded = false;

        rb2D = GetComponent<Rigidbody2D>();
    }
		
	void Update () {

        //ersetzen durch screenbuuton
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
	
	}

    void FixedUpdate()
    {

        isGrounded = groundDetector.GetComponent<BoxCollider2D>().IsTouchingLayers(whatIsGround);

        //PC testen --- erstezen durch screen button Input
        float horizontal = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(horizontal * maxSpeed, rb2D.velocity.y);

        if (jump)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }
}
