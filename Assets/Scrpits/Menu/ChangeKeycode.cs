using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeKeycode : MonoBehaviour {
    //jump left right skill
    public GameObject warn;
    float countDown = 2.0f;
    bool w = false;
    public List<Text> txt = new List<Text>();
    public List<KeyCode> keyCodes = new List<KeyCode>();
    int now = -1;
    // Update is called once per frame
    public void Init()
    {
        for (int i = 0; i < 4; i++)
            txt[i].text = keyCodes[i].ToString();
    }
    private void Update()
    {
        if (w)
        {
            warn.SetActive(true);
            countDown -= Time.fixedDeltaTime;
            if (countDown < 0)
            {
                w = false;
                countDown = 1.0f;
                warn.SetActive(false);
            }
        }
    }
    void OnGUI () {
        Event e = Event.current;
        if (now != -1)
        {
            if (e.isKey)
            {
                if (Check(e.keyCode))
                {
                    keyCodes[now] = e.keyCode;
                    txt[now].text = e.keyCode.ToString();
                }
                else w = true;
                now = -1;
            }
        }
    }
    public void setBtn(int n)
    {
        now = n;
    }

    bool Check(KeyCode k)
    {
        for (int i = 0; i < keyCodes.Count; i++)
        {
            if (i == now)
                continue;
            if (keyCodes[i] == k)
                return false;
        }
        return true;
    }
}
