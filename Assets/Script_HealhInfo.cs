using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HealhInfo : MonoBehaviour
{
    [SerializeField] GameObject HPBar;
    [SerializeField] Script_Msg msg;
    public float health = 100;
    // Update is called once per frame
    void Update()
    {
        Vector3 newS = HPBar.transform.localScale;
        newS.x = health / 100;
        HPBar.transform.localScale = newS;

        if(health <= 0)
        {
            health = 0;
            msg.AnimateText("Battle Ended!");
            Invoke("EndBattle", 3.0f);
        }
        if(health >= 100)
        {
            health = 100;
        }
    }

    void EndBattle()
    {
        GameObject.FindGameObjectWithTag("BattleMana").GetComponent<Script_BattleManager>().LeaveBattle();
    }
}
