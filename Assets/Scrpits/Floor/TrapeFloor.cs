using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapeFloor : MonoBehaviour {
    public int dmg = 20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HP>().Damage(dmg);
        }
    }
}
