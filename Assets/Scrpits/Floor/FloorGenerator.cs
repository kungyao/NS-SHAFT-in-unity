using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {
    public GameObject[] floors = new GameObject[5];
    public List<GameObject> floor = new List<GameObject>();
    public float generateRate = 2f;
    public Vector3 speed = new Vector3(0, 3, 0);
    int healPoint = 0;
    float bounce = 0 ;
    float timer = 0;
    private void Start()
    {
        generateRate = DataManager.getRate();
        speed = new Vector3(0, DataManager.getSpeed(), 0);
        healPoint = DataManager.getHeal();
        bounce = DataManager.getJumpforce();
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > generateRate)
        {
            int i = Random.Range(0, 5);
            float j = Random.Range(-5f, 5f);
            float posx = j;
            Vector3 pos = new Vector3(posx, -11f, 0);
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            GameObject tmp = Instantiate(floors[i], pos, rot);
            tmp.AddComponent<FloorMove>().speed = speed;
            if (i != 4)
                tmp.AddComponent<HealFloor>().healPoint = healPoint;
            if (i == 3)
                tmp.AddComponent<BounceFloor>().bounce = bounce;
            floor.Add(tmp);
            timer = 0;
        }
        if (floor.Count > 10)
        {
            Destroy(floor[0]);
            floor.RemoveAt(0);
        }
    }
}
