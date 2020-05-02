using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFloor : MonoBehaviour {
    public int healPoint = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HP>().Heal(healPoint);
        }
    }
}
