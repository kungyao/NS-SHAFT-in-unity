using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFLoor : MonoBehaviour {

    public int breakCount = 3;
    Animator anim;
    bool beStanded = false;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("woodFloor"))
            {
                breakCount--;
                anim.Play("woodFloor");
                if (breakCount == 0)
                    Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            breakCount = 3;
        }
    }
}
