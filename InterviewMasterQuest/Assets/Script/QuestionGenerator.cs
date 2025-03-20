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
        //–¼‘O‚ª‚ ‚Á‚Ä‚¢‚ê‚Î–â‘è‚ğo‚¹‚é
        if (nameOK == true)
        {
            Debug.Log("–â‘è‚ğo‚·");
        }
    }
}
