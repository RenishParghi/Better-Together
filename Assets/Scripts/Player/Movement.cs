using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameManager gamemanager;
    public MobileInputController joystick;

    public float runspeed = 40f;

    float horizontalmove,verticalmove = 0f;
    bool jump,crouch = false;

    private void Update()
    {
        horizontalmove = joystick.Horizontal;
        verticalmove = joystick.Vertical;

        if (joystick.Horizontal >= 0.5f)
        {
            horizontalmove = runspeed;
        }
        else if (joystick.Horizontal <= -0.5f)
        {
            horizontalmove = -runspeed;
        }
        else
        {
            horizontalmove = 0f;
        }

        if (verticalmove >= 0.5f)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D otherthing)
    {
        if (otherthing.gameObject.tag == "Killbox")
        {
            gamemanager.RestartLevel();
        }

        if (otherthing.gameObject.tag == "Wall")
        {
            jump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D otherthing)
    {
        if (otherthing.gameObject.tag == "Wall")
        {
            jump = false;
        }
    }

}
