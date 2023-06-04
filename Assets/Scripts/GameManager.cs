using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totallPlayer;
    private int targetPlayer;


    private void Awake()
    {
        Instance = this;
    }


    public void AddPlayer(int number)
    {
        targetPlayer += number;
        Winlevel();
    }

    public void RemovePlayer(int number)
    {
        targetPlayer -= number;
        Winlevel();
    }


    public void Winlevel()
    {
        if(totallPlayer <= targetPlayer)
        {
            GameOverPanelControl.Instance.EnablePanel(GameState.LevelCompleted, 1f);
        }
    }
}
