using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity = 8f;
    [SerializeField] private float rotationSpeed = 1f;

    private float rotation = 0f;

    private CharacterController charController;

    private Animator anim;

    private Vector3 moveDir = Vector3.zero;

    private float xAxis;
    private float zAxis;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        GetMoveDirection();
        СhoosePlayerAnim();
        if (IsMoving())
            Move();
    }

    private bool IsMoving()
    {
        if (xAxis != 0 || zAxis != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GetMoveDirection()
    {
        xAxis = bl_Joystick.instance.Horizontal; //Input.GetAxis("Horizontal") * moveSpeed;
        zAxis = bl_Joystick.instance.Vertical; //Input.GetAxis("Vertical") * moveSpeed;
    }

    private void СhoosePlayerAnim()
    {
        if (Mathf.Abs(zAxis) <= 0.05f)
        {
            anim.SetInteger("conditionWalk", 0);
            anim.SetInteger("conditionRun", 0);
        }
        else if (Mathf.Abs(zAxis) >  0.05f && Mathf.Abs(zAxis) <= 2.5f)
        {
            anim.SetInteger("conditionWalk", 1);
            anim.SetInteger("conditionRun", 0);
        }
        else if (Mathf.Abs(zAxis) > 2.5f)
        {
            anim.SetInteger("conditionWalk", 0);
            anim.SetInteger("conditionRun", 1);
        }
    }

    private void Move()
    {
        rotation += xAxis * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        moveDir = transform.forward * zAxis * moveSpeed * Time.deltaTime;
        moveDir.y = gravity * Time.deltaTime;
        charController.Move(moveDir);
    }
}
