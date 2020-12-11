using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BattleManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    public bool IsPlayerTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }


    public void DoneTurn(string Msg)
    {
        GetComponent<Script_Msg>().AnimateText(Msg);
        if (IsPlayerTurn)
        {
            IsPlayerTurn = false;
            enemy.GetComponent<Script_Enemy>().YourTurn();
        }
        else
        {
            Invoke("SetPlayerTurn", 3.0f);
        }
    }

    void SetPlayerTurn()
    {
        IsPlayerTurn = true;
    }

    public void Ability_Escape()
    {
        if (IsPlayerTurn)
        {
            string msg;
            if (Random.Range(0, 2) == 1)
            {
                msg = "You escaped!";
                Invoke("LeaveBattle", 3.0f);
            }
            else
            {
                msg = "You tried to escaped, but no!";
            }
            DoneTurn(msg);
        }
    }

    public void LeaveBattle()
    {
        player.SetActive(true);
        player.GetComponent<Script_RandomBattle>().SetLastPosition();
        player.GetComponentInParent<PlayerCharacterController>().IsPaused = false;
        SceneManager.LoadScene("Map_GameWorld");
    }
}
