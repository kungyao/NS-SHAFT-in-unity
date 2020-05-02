using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveKey : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    static string path = "";
    List<KeyCode> keyCodes = new List<KeyCode>();
    // Use this for initialization
    void Start () {
        path = Application.dataPath + "/PlayerSetting";
        string data = "";
        if (System.IO.File.Exists(path))
        {
            data = System.IO.File.ReadAllText(path);
        }
        KeyHandler tmp = JsonUtility.FromJson<KeyHandler>(data);
        keyCodes = tmp.keyCodes;
        if (keyCodes.Count == 8)
            givePlayerKey();
    }
	
    public void WriteKey()
    {
        getPlayerKey();
        KeyHandler tmp = new KeyHandler(keyCodes);
        string data = JsonUtility.ToJson(tmp);
        print(data);
        System.IO.File.WriteAllText(path, data);
    }

    void getPlayerKey()
    {
        keyCodes = new List<KeyCode>();
        ChangeKeycode tmp1 = player1.GetComponent<ChangeKeycode>();
        ChangeKeycode tmp2 = player2.GetComponent<ChangeKeycode>();
        for (int i = 0; i < 4; i++)
            keyCodes.Add(tmp1.keyCodes[i]);
        for (int i = 0; i < 4; i++)
            keyCodes.Add(tmp2.keyCodes[i]);
    }

    void givePlayerKey()
    {
        ChangeKeycode tmp1 = player1.GetComponent<ChangeKeycode>();
        tmp1.keyCodes = new List<KeyCode>();
        ChangeKeycode tmp2 = player2.GetComponent<ChangeKeycode>();
        tmp2.keyCodes = new List<KeyCode>();
        for (int i = 0; i < keyCodes.Count - 4; i++)
            tmp1.keyCodes.Add(keyCodes[i]);
        for (int i = 4; i < keyCodes.Count; i++)
            tmp2.keyCodes.Add(keyCodes[i]);
        tmp1.Init();
        tmp2.Init();
    }

    public void Play()
    {
        DataManager.player1 = player1.GetComponent<ChangeKeycode>().keyCodes;
        DataManager.player2 = player2.GetComponent<ChangeKeycode>().keyCodes;
    }
}
