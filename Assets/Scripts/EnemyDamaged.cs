using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public float health; // ü��
    public float maxHealth; // �ִ� ü��

    void Start()
    {
        health = maxHealth; // ������ �����ϸ� ü���� �ִ�ü������
    }

    public void DealDamage(float damage)
    {
        health -= damage; // ü�¿��� ��������ŭ ����
        CheckDeath(); // �׾����� Ȯ��
    }

    private void CheckOverheal()
    {
        if (health > maxHealth) // ü���� �ִ�ü�º��� ������
        {
            health = maxHealth; // ü���� �ִ�ü������
        }
    }

    private void CheckDeath()
    {
        if (health <= 0) // ü���� 0���� ������
        {
            Destroy(gameObject); // �� �ı�
        }
    }
}
