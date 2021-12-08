using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamaged : MonoBehaviour
{
    public float health; // 체력
    public float maxHealth; // 최대 체력

    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        health = maxHealth; // 게임이 시작하면 체력을 최대체력으로
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        health -= damage; // 체력에서 데미지만큼 감소
        CheckDeath(); // 죽었는지 확인
    }

    public void HealCharacter(float heal)
    {
        health += heal; // 체력에서 회복량만큼 추가
        CheckOverheal(); // 회복된 체력이 최대체력보다 큰지 확인
        healthBarSlider.value = CalculateHealthPercentage();
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
            Destroy(gameObject); // 적 파괴
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
