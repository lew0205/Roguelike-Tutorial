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

    public float health; // 체력
    public float maxHealth; // 최대 체력
    public float stamina;
    public float maxStamina;

    private void Awake()
    {
        if(playerStats!=null)
        {
            Destroy(playerStats); // 플레이어 스탯이 중복되면 안되므로 게임 시작 시 기존에 스텟이 있다면 기존의 스텟을 삭제한다.
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this); // 씬이 바뀌어도 파괴되지 않게 한다.
    }

    void Start()
    {
        healthText.GetComponent<TextMeshProUGUI>();
        staminaText.GetComponent<TextMeshProUGUI>();

        health = maxHealth; // 게임이 시작하면 체력을 최대체력으로
        healthSlider.value = 1;
        stamina = maxStamina; // 게임이 시작하면 기력을 최대기력으로
        staminaSlider.value = 1;
        SetHealthUI();
        SetStaminaUI();
    }

    public void DealDamage(float damage)
    {
        health -= damage; // 체력에서 데미지만큼 감소
        CheckDeath(); // 죽었는지 확인
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal; // 체력에서 회복량만큼 추가
        CheckOverheal(); // 회복된 체력이 최대체력보다 큰지 확인
        SetHealthUI();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth) // 체력이 최대체력보다 많으면
        {
            health = maxHealth; // 체력을 최대체력으로
        }
    }

    private void CheckDeath()
    {
        if (health <= 0) // 체력이 0보다 적으면
        {
            health = 0;
            Destroy(player); // 적 파괴
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
