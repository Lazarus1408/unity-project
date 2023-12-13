using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody theRB; // promenljive iskoriscene za kretanje po sceni
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround; // proemljive za skok
    public Transform groundPoint;
    private bool isGrounded;

    public SpriteRenderer theSR; // promenljiva za okretanje po x osi

    private bool movingBackwards;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal"); // kretanje
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y,
            moveInput.y * moveSpeed);

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, 20.25f, whatIsGround)) // skok
        {

            isGrounded = true;
            

        }
        else
        { 

            isGrounded = false;
            
        }
        if (Input.GetButtonDown("Jump")!&& isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        if(!theSR.flipX && moveInput.x <0) // okretanje po x osi
        {
            theSR.flipX = true;

        }
        else if (theSR.flipX && moveInput.x >0)
        {
            theSR.flipX =false;
        }

        if(!movingBackwards && moveInput.y <0)
            // petlja za okretanje odpozadi ako imamo tu potrebu
            // (na to se u  animatoru posle dodaju animacije)
        {
            movingBackwards = true;
        }
        else if (movingBackwards && moveInput.y >0)
        {
           movingBackwards = false;
        }

    }
}
