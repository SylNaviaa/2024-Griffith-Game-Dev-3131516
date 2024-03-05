using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public Rigidbody2D myRB;
    public float jumpForce;
    public bool isGrounded;
    public float secondaryJumpTime;
    public float secondaryJumpForce;
    public bool secondaryJump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f ) {

            myRB.AddForce(new Vector2(x:Input.GetAxis("Horizontal") * acceleration, y:0), ForceMode2D.Force);
        }
        if (isGrounded && Input.GetButtonDown("Jump")) 
        { 
            myRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            StartCoroutine(SecondaryJump());
        }
        if (isGrounded == false && Input.GetButton("Jump"))
        {
            myRB.AddForce(new Vector2(0, secondaryJumpForce), ForceMode2D.Force);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // as long as a collider is detected inside, the player is grounded
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    IEnumerator SecondaryJump()
    {
        secondaryJump = true;
        yield return new WaitForSeconds(secondaryJumpTime);
        secondaryJump = false;
        yield return null;
    }
}
