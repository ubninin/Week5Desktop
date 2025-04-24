using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    private void FixedUpdate()
    {
        //if (movement.x!=0 || movement.y != 0){rb.linearVelocity = movement * speed;}//방법0마찰없이 움직임
        //리귀드바디-리니어어쩌구로 마찰력 조절가능
        rb.linearVelocity = movement * speed; //방법1

        //rb.MovePosition(rb.position + movement * speed*Time.fixedDeltaTime); //방법2(1과거의같음)
        //rb.AddForce(movement * speed); //방법4 마찰있는방법0이랑 비슷함 가속붙음

    }
}
