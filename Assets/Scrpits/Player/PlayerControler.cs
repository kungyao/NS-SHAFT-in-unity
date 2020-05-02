using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float JumpForce = 400f;
    public float moveSpeed = 5f;
    public LayerMask groundLayer;
    bool faceRight = true;
    bool isGrounded = false;
    bool Jumping = false;
    Collider2D myCollider;
    Rigidbody2D myRigidbody;
    Animator anim;
    float skillCountDown = -0.1f;

	void Start () {
        anim = this.GetComponent<Animator>();
        myCollider = this.GetComponent<BoxCollider2D>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update () {
        skillCountDown -= Time.deltaTime;
        float h = Input.GetAxis("Horizontal");
        /*Vector2 start = this.transform.position;
        Vector2 end = new Vector2(start.x, start.y - 1.5f);
        isGrounded = Physics2D.Linecast(start, end, groundLayer);*/
        isGrounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        anim.SetBool("isGrounded", isGrounded);

        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.Z) ) //&& skillCountDown < 0
        {
            anim.SetTrigger("SwordExplosion");
            skillCountDown = 5.0f;
        }
    }

    void FlipCharacter()
    {
        faceRight = !faceRight;
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        // Move the charactermyRigidbody.velocity.y)
        myRigidbody.velocity = new Vector2(h * moveSpeed, myRigidbody.velocity.y);
        if (h < 0 && faceRight)
            FlipCharacter();
        else if (h > 0 && !faceRight)
            FlipCharacter();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            myRigidbody.AddForce(new Vector2(0f, JumpForce));
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Jumping = true;
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
        }
        //rightWall = false;
        //leftWall = false;
    }*/
}
