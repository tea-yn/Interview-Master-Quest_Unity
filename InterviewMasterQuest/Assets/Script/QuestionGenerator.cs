using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public GameObject question;
    public Boolean nameOK = false;

    // Update is called once per frame
    void Update()
    {
        //���O�������Ă���Ζ����o����
        if (nameOK == true)
        {
            Debug.Log("�����o��");
        }
    }
}
