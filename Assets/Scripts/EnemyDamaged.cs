using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamaged : MonoBehaviour
{
    public float health; // ü��
    public float maxHealth; // �ִ� ü��

    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        health = maxHealth; // ������ �����ϸ� ü���� �ִ�ü������
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        health -= damage; // ü�¿��� ��������ŭ ����
        CheckDeath(); // �׾����� Ȯ��
    }

    public void HealCharacter(float heal)
    {
        health += heal; // ü�¿��� ȸ������ŭ �߰�
        CheckOverheal(); // ȸ���� ü���� �ִ�ü�º��� ū�� Ȯ��
        healthBarSlider.value = CalculateHealthPercentage();
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

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
