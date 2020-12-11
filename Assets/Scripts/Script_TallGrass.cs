using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TallGrass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Script_RandomBattle>().ShouldCount = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Script_RandomBattle>().ShouldCount = false;
        }
    }
}
