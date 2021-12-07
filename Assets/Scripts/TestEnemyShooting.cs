using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile; // ����ü ������Ʈ
    public Transform player;
    public float minDamage; // �ּ� ������
    public float maxDamage; // �ִ� ������
    public float projectileForce; // ����ü �ӵ�
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
