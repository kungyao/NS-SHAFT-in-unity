using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFlame : MonoBehaviour {

    float destroyTime = 2.0f;
    private void FixedUpdate()
    {
        destroyTime -= Time.fixedDeltaTime;
        if (destroyTime < 0)
            Destroy();
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" || collision.tag != "Floor")
            Destroy();
    }
}
