using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage; // ������
    public float pjTime = 4;

    private void Awake()
    {
        StartCoroutine(BreakProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag!="Enemy") // �ڱ��ڽ��� �����ϰ� �ε����ٸ�
        {
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
            Destroy(gameObject); // ����ü �ı�
        }
    }

    IEnumerator BreakProjectile()
    {
        yield return new WaitForSeconds(pjTime);
        Destroy(gameObject);
    }
}
