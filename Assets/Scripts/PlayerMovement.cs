using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // 이동 속도
    private Vector2 direction; // 이동 방향
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
        transform.Translate(direction * speed * Time.deltaTime); // 이동 속도만큼 이동 방향으로 이동

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction); // 애니메이션에 이동 방향을 전달
        }
        else
        {
            animator.SetLayerWeight(1, 0); // Walking 레이어 애니메이션이 실행되게
        }
    }

    private void TakeInput()
    {
        direction = Vector2.zero; // 이동 방향 초기화

        if (Input.GetKey(KeyCode.W)) // W를 누를 시
        {
            direction += Vector2.up; // 이동 방향을 위로 설정 
        }
        if (Input.GetKey(KeyCode.S)) // S를 누를 시
        {
            direction += Vector2.down; // 이동 방향을 아래로 설정
        }
        if (Input.GetKey(KeyCode.A)) // A를 누를 시
        {
            direction += Vector2.left; // 이동 방향을 왼쪽으로 설정
        }
        if (Input.GetKey(KeyCode.D)) // D를 누를 시
        {
            direction += Vector2.right; // 이동 방향을 오른쪽으로 설정
        }

    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1); // Idle 레이어 애니메이션이 실행되게
        animator.SetFloat("xDir", direction.x); // x축 방향을 애니메이션에 전달
        animator.SetFloat("yDir", direction.y); // y축 방향을 애니메이션에 전달
    }
}
