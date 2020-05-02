using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Dropdown player;
    public Dropdown level;
    public void setSetting()
    {
        DataManager.player = player.value;
        DataManager.level = level.value;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("B10515028", LoadSceneMode.Single);
    }
}
