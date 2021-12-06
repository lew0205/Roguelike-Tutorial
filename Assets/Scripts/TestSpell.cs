using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile; // 투사체 오브젝트
    public float minDamage; // 최소 데미지
    public float maxDamage; // 최대 데미지
    public float projectileForce; // 투사체 속도

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 입력되면 발사되는 식인듯
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity); // 오브젝트 생성(투사체, 생성 위치(캐릭터위치), 방향 뜻은 모르겠음)
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스가 클릭된 좌표
            Vector2 myPos = transform.position; // 캐릭터 위치
            Vector2 direction = (mousePos - myPos).normalized; // 투사체 발사 방향
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce; // 방향으로 투사체 속도로 발사
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage); // 투사체의 데미지를 최소 데미지에서 최대 데미지 사이로 설정
        }
    }
}
