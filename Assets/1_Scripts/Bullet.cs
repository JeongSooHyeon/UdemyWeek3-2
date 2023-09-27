using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;    // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;  // �̵��� ����� ������ٵ� ������Ʈ

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Ʈ���� �浹 �� �ڵ����� ����
    private void OnTriggerEnter(Collider other)
    {
        // �⵿�� ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
        PlayerController playerController = other.GetComponent<PlayerController>();

        // �������κ��� PlayerController ������Ʈ�� �������� �� ����
        if(playerController != null && !playerController.isInvincible)
        {
            // ���� PlayerController ������Ʈ�� Die() �޼��� ����
            playerController.Die();
        }
    }
}
