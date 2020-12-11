using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPrefab2;
    [SerializeField] GameObject bulletPoint;
    [SerializeField] Script_BattleManager BM;
    [SerializeField] Script_HealhInfo PlayerHealth;
    [SerializeField] AudioClip SE_Stra;
    [SerializeField] AudioClip SE_Pine;
    [SerializeField] AudioClip SE_Heal;
    [SerializeField] ParticleSystem PE_Heal;
    private AudioSource Audio;
    private float currentDmg;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void ShootBullet()
    {
        GameObject.Instantiate(bulletPrefab, bulletPoint.transform.position, new Quaternion());
        BM.DoneTurn("Cannon monster fired a STRAWBERRY at you. \nWaht are you going to do next?");
        Audio.clip = SE_Stra;
        Audio.Play();
        currentDmg = 13;
        Invoke("ApplyDmg", 2.0f);
    }

    void Heal()
    {
        BM.DoneTurn("Cannon monster used Heal. \nWaht are you going to do next?");
        Audio.clip = SE_Heal;
        PE_Heal.Play();
        Audio.Play();
        GetComponent<Script_HealhInfo>().health += 25.0f;
    }

    void ShootBullet2()
    {
        GameObject.Instantiate(bulletPrefab2, bulletPoint.transform.position, new Quaternion());
        BM.DoneTurn("Cannon monster fired a PINEAPPLE at you. \nWaht are you going to do next?");
        Audio.clip = SE_Pine;
        Audio.Play();
        currentDmg = 25;
        Invoke("ApplyDmg", 2.0f);
    }

    public void YourTurn()
    {
        int randomAP = Random.Range(0, 3);
        switch (randomAP)
        {
            case 0:
                Invoke("ShootBullet", 5.0f);
                break;
            case 1:
                Invoke("Heal", 5.0f);
                break;
            case 2:
                Invoke("ShootBullet2", 5.0f);
                break;
            default:
                Invoke("ShootBullet", 5.0f);
                break;
        }
    }

    void ApplyDmg()
    {
        PlayerHealth.health -= currentDmg + Random.Range(0, 5);
    }
}
