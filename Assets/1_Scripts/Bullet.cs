using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;    // 탄알 이동 속력
    private Rigidbody bulletRigidbody;  // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // 트리거 충돌 시 자동으로 실행
    private void OnTriggerEnter(Collider other)
    {
        // 출동한 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
        PlayerController playerController = other.GetComponent<PlayerController>();

        // 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공
        if(playerController != null && !playerController.isInvincible)
        {
            // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
            playerController.Die();
        }
    }
}
