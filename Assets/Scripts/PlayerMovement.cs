using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // �̵� �ӵ�
    private Vector2 direction; // �̵� ����
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime); // �̵� �ӵ���ŭ �̵� �������� �̵�

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction); // �ִϸ��̼ǿ� �̵� ������ ����
        }
        else
        {
            animator.SetLayerWeight(1, 0); // Walking ���̾� �ִϸ��̼��� ����ǰ�
        }
    }

    private void TakeInput()
    {
        direction = Vector2.zero; // �̵� ���� �ʱ�ȭ

        if (Input.GetKey(KeyCode.W)) // W�� ���� ��
        {
            direction += Vector2.up; // �̵� ������ ���� ���� 
        }
        if (Input.GetKey(KeyCode.S)) // S�� ���� ��
        {
            direction += Vector2.down; // �̵� ������ �Ʒ��� ����
        }
        if (Input.GetKey(KeyCode.A)) // A�� ���� ��
        {
            direction += Vector2.left; // �̵� ������ �������� ����
        }
        if (Input.GetKey(KeyCode.D)) // D�� ���� ��
        {
            direction += Vector2.right; // �̵� ������ ���������� ����
        }

    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1); // Idle ���̾� �ִϸ��̼��� ����ǰ�
        animator.SetFloat("xDir", direction.x); // x�� ������ �ִϸ��̼ǿ� ����
        animator.SetFloat("yDir", direction.y); // y�� ������ �ִϸ��̼ǿ� ����
    }
}
