using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

    private int rotationDir;
    private float randInterval = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        randInterval += Time.deltaTime;
        if(randInterval >= 3)
        {
            randInterval = 0f;
            rotationSpeed = Random.Range(30, 80);
            rotationDir = Random.Range(0, 2);
            if(rotationDir == 0)    // 25ÆÛ¼¾Æ® È®·ü
            {
                rotationSpeed *= -1;
            }
        }
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
