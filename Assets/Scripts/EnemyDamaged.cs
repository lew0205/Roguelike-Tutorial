using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public float health; // 체력
    public float maxHealth; // 최대 체력

    void Start()
    {
        health = maxHealth; // 게임이 시작하면 체력을 최대체력으로
    }

    public void DealDamage(float damage)
    {
        health -= damage; // 체력에서 데미지만큼 감소
        CheckDeath(); // 죽었는지 확인
    }

    private void CheckOverheal()
    {
        if (health > maxHealth) // 체력이 최대체력보다 많으면
        {
            health = maxHealth; // 체력을 최대체력으로
        }
    }

    private void CheckDeath()
    {
        if (health <= 0) // 체력이 0보다 적으면
        {
            Destroy(gameObject); // 적 파괴
        }
    }
}
