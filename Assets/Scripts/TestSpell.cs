using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile; // ����ü ������Ʈ
    public float minDamage; // �ּ� ������
    public float maxDamage; // �ִ� ������
    public float projectileForce; // ����ü �ӵ�

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� �ԷµǸ� �߻�Ǵ� ���ε�
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity); // ������Ʈ ����(����ü, ���� ��ġ(ĳ������ġ), ���� ���� �𸣰���)
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺�� Ŭ���� ��ǥ
            Vector2 myPos = transform.position; // ĳ���� ��ġ
            Vector2 direction = (mousePos - myPos).normalized; // ����ü �߻� ����
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce; // �������� ����ü �ӵ��� �߻�
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage); // ����ü�� �������� �ּ� ���������� �ִ� ������ ���̷� ����
        }
    }
}
