using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage; // 데미지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player") // 자기자신을 제외하고 부딪힌다면
        {
            if (collision.GetComponent<EnemyDamaged>() != null) // 적이 데미지를 입으면
            {
                collision.GetComponent<EnemyDamaged>().DealDamage(damage); // 적에게 데미지를 부여
            }
            Destroy(gameObject); // 투사체 파괴
        }
    }
}
