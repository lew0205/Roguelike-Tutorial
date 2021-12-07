using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage; // 데미지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag!="Enemy") // 자기자신을 제외하고 부딪힌다면
        {
            Destroy(gameObject); // 투사체 파괴
        }
    }
}
