using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats; 

    public GameObject player;

    public float health; // ü��
    public float maxHealth; // �ִ� ü��

    private void Awake()
    {
        if(playerStats!=null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth; // ������ �����ϸ� ü���� �ִ�ü������
    }

    public void DealDamage(float damage)
    {
        health -= damage; // ü�¿��� ��������ŭ ����
        CheckDeath(); // �׾����� Ȯ��
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
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
            Destroy(player); // �� �ı�
        }
    }
}
