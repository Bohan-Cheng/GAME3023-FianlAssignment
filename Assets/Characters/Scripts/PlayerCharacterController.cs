using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2(MoveX, MoveY);

        if(MoveX > 0.1f) { anim.SetInteger("Direction", 3); }
        if(MoveX < -0.1f) { anim.SetInteger("Direction", 2); }
        if(MoveY > 0.1f) { anim.SetInteger("Direction", 0); }
        if(MoveY < -0.1f) { anim.SetInteger("Direction", 1); }

        if(rigidBody.velocity.magnitude > 0.5f)
        {
            GetComponent<Script_RandomBattle>().AddStep();
            anim.speed = 1.0f;
        }
        else if(rigidBody.velocity.magnitude <= 0.1f)
        {
            anim.speed = 0.0f;
        }
        movementVector *= speed;
        rigidBody.velocity = movementVector;
    }
}