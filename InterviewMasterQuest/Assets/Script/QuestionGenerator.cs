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
        //名前があっていれば問題を出せる
        if (nameOK == true)
        {
            Debug.Log("問題を出す");
        }
    }
}
