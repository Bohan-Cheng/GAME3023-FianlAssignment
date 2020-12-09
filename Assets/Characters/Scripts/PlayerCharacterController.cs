using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(rigidBody.velocity.magnitude > 0.5f)
        {
            GetComponent<Script_RandomBattle>().AddStep();
        }
        movementVector *= speed;
        rigidBody.velocity = movementVector;
    }
}