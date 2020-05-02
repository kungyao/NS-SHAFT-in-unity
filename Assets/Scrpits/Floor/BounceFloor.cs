using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFloor : MonoBehaviour {
    public float bounce = 1.0f;
    Animator anim;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (anim)
                anim.Play("bounceFloor");
            collision.rigidbody.AddForce(new Vector2(0, bounce));
        }
    }
}
