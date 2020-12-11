using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BattleManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ability_Escape()
    {
        player.SetActive(true);
        player.GetComponent<Script_RandomBattle>().SetLastPosition();
        player.GetComponentInParent<PlayerCharacterController>().IsPaused = false;
        SceneManager.LoadScene("Map_GameWorld");
    }
}
