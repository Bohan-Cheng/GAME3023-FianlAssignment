using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerAbilities : MonoBehaviour
{
    [SerializeField] ParticleSystem PE_Fireball;
    [SerializeField] ParticleSystem PE_Burn;
    [SerializeField] ParticleSystem PE_ToxicRain;
    [SerializeField] ParticleSystem PE_Heal;
    [SerializeField] AudioClip SE_Fireball;
    [SerializeField] AudioClip SE_Rain;
    [SerializeField] AudioClip SE_Heal;
    [SerializeField] Script_HealhInfo EnemyInfo;
    [SerializeField] Script_HealhInfo PlayerInfo;
    private Script_BattleManager BM;
    private AudioSource Audio;
    private float currentDmg;

    private void Start()
    {
        BM = GetComponent<Script_BattleManager>();
        Audio = GetComponent<AudioSource>();
    }

    public void Fireball()
    {
        if (BM.IsPlayerTurn)
        {
            BM.DoneTurn("You used Fireball!");
            PE_Fireball.Play();
            Audio.clip = SE_Fireball;
            Audio.Play();
            Invoke("Burnning", 1.2f);
            currentDmg = 10;
            Invoke("DoDmg", 1.2f);
        }
    }

    public void ToxicRain()
    {
        if (BM.IsPlayerTurn)
        {
            BM.DoneTurn("You used Toxic Rain!");
            PE_ToxicRain.Play();
            Audio.clip = SE_Rain;
            Audio.Play();
            currentDmg = 18;
            Invoke("DoDmg", 1.2f);
        }
    }

    public void Heal()
    {
        if (BM.IsPlayerTurn)
        {
            BM.DoneTurn("You Healed!");
            PE_Heal.Play();
            Audio.clip = SE_Heal;
            Audio.Play();
            PlayerInfo.health += 30;
        }
    }

    void Burnning()
    {
        PE_Burn.Play();
    }

    void DoDmg()
    {
        EnemyInfo.health -= currentDmg + Random.Range(0, 5);
    }
}
