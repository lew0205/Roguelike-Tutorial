using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage; // ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player") // �ڱ��ڽ��� �����ϰ� �ε����ٸ�
        {
            if (collision.GetComponent<EnemyDamaged>() != null) // ���� �������� ������
            {
                collision.GetComponent<EnemyDamaged>().DealDamage(damage); // ������ �������� �ο�
            }
            Destroy(gameObject); // ����ü �ı�
        }
    }
}
