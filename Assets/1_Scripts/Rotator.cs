using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;   // 회전 속력

    private int rotationDir;    // 회전 방향
    private float randInterval = 0f;    // 회전 랜덤 주기

    void Update()
    {
        randInterval += Time.deltaTime;

        if((int)randInterval >= 3)   // 3초 이상 지났으면
        {
            randInterval = 0f;  // 랜덤 주기 초기화
            rotationSpeed = Random.Range(30, 80);   // 랜덤으로 속력 정하기

            // 50% 확률로 회전 방향 바꾸기
            rotationDir = Random.Range(0, 2);  
            if(rotationDir == 0)    
            {
                rotationSpeed *= -1;
            }
        }

        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
