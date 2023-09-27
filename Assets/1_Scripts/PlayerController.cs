using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;

    public bool isInvincible = false;   // �����ΰ�?

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ������ٵ� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;

/*        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� z ���� �� �ֱ�
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� -z ���� �� �ֱ�
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� x ���� �� �ֱ�
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        if (gameManager == null)
            Debug.Log("sssssssssss");
        gameManager.EndGame();
    }
}
