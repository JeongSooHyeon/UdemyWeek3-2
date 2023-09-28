using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;   // ȸ�� �ӷ�

    private int rotationDir;    // ȸ�� ����
    private float randInterval = 0f;    // ȸ�� ���� �ֱ�

    void Update()
    {
        randInterval += Time.deltaTime;

        if((int)randInterval >= 3)   // 3�� �̻� ��������
        {
            randInterval = 0f;  // ���� �ֱ� �ʱ�ȭ
            rotationSpeed = Random.Range(30, 80);   // �������� �ӷ� ���ϱ�

            // 50% Ȯ���� ȸ�� ���� �ٲٱ�
            rotationDir = Random.Range(0, 2);  
            if(rotationDir == 0)    
            {
                rotationSpeed *= -1;
            }
        }

        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
