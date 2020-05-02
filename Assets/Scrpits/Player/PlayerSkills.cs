using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {

    public List<GameObject> sword;
    public float Speed = 1000.0f;
    public Transform center;//腳色中心
	// Use this for initialization
    void SkillAttack()
    {
        for (int i = 0; i < sword.Count; i++)
        {
            GameObject tmp = Instantiate(sword[i],sword[i].transform.position,Quaternion.Euler(sword[i].transform.eulerAngles)) as GameObject;
            Vector2 forward = new Vector2(tmp.transform.position.x - center.position.x, tmp.transform.position.y - center.position.y);
            tmp.GetComponent<Rigidbody2D>().AddForce(Speed * forward);
            tmp.GetComponent<BoxCollider2D>().enabled = true;
            tmp.AddComponent<TheFlame>();
        }
    }
}
