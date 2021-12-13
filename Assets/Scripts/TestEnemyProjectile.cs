using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage; // 데미지
    public float pjTime = 4;

    private void Awake()
    {
        StartCoroutine(BreakProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag!="Enemy") // 자기자신을 제외하고 부딪힌다면
        {
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
            Destroy(gameObject); // 투사체 파괴
        }
    }

    IEnumerator BreakProjectile()
    {
        yield return new WaitForSeconds(pjTime);
        Destroy(gameObject);
    }
}
