using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HealhInfo : MonoBehaviour
{
    [SerializeField] GameObject HPBar;
    [SerializeField] Script_Msg msg;
    public float health = 100;
    public bool IsPlayer = false;
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            if(IsPlayer) { msg.text.text = "Battle Ended! YOU LOST."; }
            else { msg.text.text = "Battle Ended! YOU WON!"; }
            Invoke("EndBattle", 3.0f);
        }
        if(health >= 100) { health = 100; }

        Vector3 newS = HPBar.transform.localScale;
        newS.x = health / 100;
        HPBar.transform.localScale = newS;
    }

    void EndBattle()
    {
        GameObject.FindGameObjectWithTag("BattleMana").GetComponent<Script_BattleManager>().LeaveBattle();
    }
}
