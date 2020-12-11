using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPoint;
    [SerializeField] Script_BattleManager BM;
    [SerializeField] Script_HealhInfo PlayerHealth;

    void ShootBullet()
    {
        GameObject.Instantiate(bulletPrefab, bulletPoint.transform.position, new Quaternion());
        BM.DoneTurn("Canon monster fired a strabarry at you, waht are you going to do?");
        Invoke("ApplyDmg", 2.0f);
    }

    public void YourTurn()
    {
        Invoke("ShootBullet", 5.0f);
    }

    void ApplyDmg()
    {
        PlayerHealth.health -= 13;
    }
}
