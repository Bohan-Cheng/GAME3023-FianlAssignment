using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(280.0f, 400.0f));
        GetComponent<Rigidbody2D>().angularVelocity = -180.0f;
        Invoke("KillSelf", 5.0f);
    }

    void KillSelf()
    {
        Destroy(gameObject);
    }
}
