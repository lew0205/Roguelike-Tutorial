using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage; // ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag!="Enemy") // �ڱ��ڽ��� �����ϰ� �ε����ٸ�
        {
            Destroy(gameObject); // ����ü �ı�
        }
    }
}
