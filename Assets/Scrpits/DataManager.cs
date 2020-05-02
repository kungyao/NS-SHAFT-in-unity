using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager {
    static public List<KeyCode> player1;
    static public List<KeyCode> player2;
    static public int player; //1 2
    static public int level; //0 easy  1 normal  2 hard
    //heal rate speed jumpforce
    static private float[,] ability = new float[3, 4]
    { { 10, 2.5f, 2.5f, 400 }, { 5, 4.0f, 1.0f, 500 }, {  1, 5.5f, 1.0f, 600 } };

    static public int getHeal() { return Mathf.FloorToInt(ability[level, 0]); }
    static public float getRate() { return ability[level, 1]; }
    static public float getSpeed() { return ability[level, 2]; }
    static public float getJumpforce() { return ability[level, 3]; }
}
