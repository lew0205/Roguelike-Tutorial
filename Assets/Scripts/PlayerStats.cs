using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats; 
    public GameObject player;
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public TextMeshProUGUI staminaText;
    public Slider staminaSlider;

    public float health; // ü��
    public float maxHealth; // �ִ� ü��
    public float stamina;
    public float maxStamina;

    private void Awake()
    {
        if(playerStats!=null)
        {
            Destroy(playerStats); // �÷��̾� ������ �ߺ��Ǹ� �ȵǹǷ� ���� ���� �� ������ ������ �ִٸ� ������ ������ �����Ѵ�.
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this); // ���� �ٲ� �ı����� �ʰ� �Ѵ�.
    }

    void Start()
    {
        healthText.GetComponent<TextMeshProUGUI>();
        staminaText.GetComponent<TextMeshProUGUI>();

        health = maxHealth; // ������ �����ϸ� ü���� �ִ�ü������
        healthSlider.value = 1;
        stamina = maxStamina; // ������ �����ϸ� ����� �ִ�������
        staminaSlider.value = 1;
        SetHealthUI();
        SetStaminaUI();
    }

    public void DealDamage(float damage)
    {
        health -= damage; // ü�¿��� ��������ŭ ����
        CheckDeath(); // �׾����� Ȯ��
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal; // ü�¿��� ȸ������ŭ �߰�
        CheckOverheal(); // ȸ���� ü���� �ִ�ü�º��� ū�� Ȯ��
        SetHealthUI();
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
            health = 0;
            Destroy(player); // �� �ı�
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
    
    private float CalculateStaminaPercentage()
    {
        return (stamina / maxStamina);
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health) + "/" + Mathf.Ceil(maxHealth);
    }

    private void SetStaminaUI()
    {
        staminaSlider.value = CalculateStaminaPercentage();
        staminaText.text = Mathf.Ceil(stamina) + "/" + Mathf.Ceil(maxStamina);
    }
}
