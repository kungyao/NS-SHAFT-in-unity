using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> playerPre;
    public GameObject canvas;
    public List<GameObject> player = new List<GameObject>();
    List<HP> hp = new List<HP>();
    int n = 0;
    bool hasPlayer = false;
    private void Start()
    {
        player.Clear();
        hp.Clear();
        hasPlayer = true;
        n = DataManager.player + 1;
        for (int i = 0; i < n; i++)
        {
            GameObject tmp = Instantiate(playerPre[i]);
            tmp.SetActive(true);
            player.Add(tmp);
            hp.Add(tmp.GetComponent<HP>());
        }
    }
    private void Update()
    {
        if(hasPlayer)
        {
            Check();
            ClearPlayer();
            if (player.Count == 0)
            {
                canvas.SetActive(true);
            }
        }
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("B10515028", LoadSceneMode.Single);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Begin", LoadSceneMode.Single);
    }

    void Check()
    {
        for(int i = 0; i < n; i++)
        {
            if (hp[i].IsDead())
            {
                Destroy(player[i]);
            }
        }
    }
    void ClearPlayer()
    {
        for (int i = 0; i < player.Count; i++) 
            if (!player[i])
            {
                player.RemoveAt(i);
                i--;
            }
    }
}
