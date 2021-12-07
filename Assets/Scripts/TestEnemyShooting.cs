using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile; // 투사체 오브젝트
    public Transform player;
    public float minDamage; // 최소 데미지
    public float maxDamage; // 최대 데미지
    public float projectileForce; // 투사체 속도
    public float cooldown;

    private void Start()
    {
        StartCoroutine(ShootingPlayer());
    }

    IEnumerator ShootingPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootingPlayer());
        }
    }
}
