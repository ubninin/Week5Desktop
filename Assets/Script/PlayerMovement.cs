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
        //if (movement.x!=0 || movement.y != 0){rb.linearVelocity = movement * speed;}//���0�������� ������
        //���͵�ٵ�-���Ͼ��¼���� ������ ��������
        rb.linearVelocity = movement * speed; //���1

        //rb.MovePosition(rb.position + movement * speed*Time.fixedDeltaTime); //���2(1�����ǰ���)
        //rb.AddForce(movement * speed); //���4 �����ִ¹��0�̶� ����� ���Ӻ���

    }
}
