using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text inputUsernameText;   //���[�U�[�̓��͂������O
    public TMP_Text problemText;    //�w�����̃e�L�X�g
    public TextMeshProUGUI interviewerText;    //�ʐڊ����b���e�L�X�g

    //public GameObject nameQuestion;
    public Boolean nameOK = false;

    public GameObject questionOJT;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        interviewerText.text = "����ł́A�����O���ǂ���";
    }

    //OnValueChanged�ɓo�^
    public void OnSubmit()
    {
        Debug.Log("OnSubmit���\�b�h�����s");
        interviewerText.text = inputUsernameText.text + "����ł���";        
    }

    public void ClickOkButton()
    {
        //Button�𐶐����Ă͂��Ƃ�������\��������
        //�͂���Button�Ȃ�����o��
        nameOK = true;
        //�������Ȃ�ēx���O�𕷂�
        CreateQuestion();
    }


    public void CreateQuestion()
    {
        //userNameText.text = inputField.text;

        //���O�������Ă���Ζ����o����
        if (nameOK == true)
        {
            Debug.Log("�����o��");
            interviewerText.text = "����ł�" + inputUsernameText.text + "����A����ł�";
            Destroy(this.gameObject);
            Destroy(interviewerText);

            Instantiate(questionOJT, new Vector3(540.0f, 960.0f, 0f), Quaternion.identity);
        }
    }
}
