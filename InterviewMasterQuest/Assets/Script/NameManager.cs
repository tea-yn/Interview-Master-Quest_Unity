using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text inputUsernameText;   //ユーザーの入力した名前
    public TMP_Text problemText;    //指示文のテキスト
    public TextMeshProUGUI interviewerText;    //面接官が話すテキスト

    //public GameObject nameQuestion;
    public Boolean nameOK = false;

    public GameObject questionOJT;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        interviewerText.text = "それでは、お名前をどうぞ";
    }

    //OnValueChangedに登録
    public void OnSubmit()
    {
        Debug.Log("OnSubmitメソッドを実行");
        interviewerText.text = inputUsernameText.text + "さんですね";        
    }

    public void ClickOkButton()
    {
        //Buttonを生成してはいといいえを表示させる
        //はいのButtonなら問題を出す
        nameOK = true;
        //いいえなら再度名前を聞く
        CreateQuestion();
    }


    public void CreateQuestion()
    {
        //userNameText.text = inputField.text;

        //名前があっていれば問題を出せる
        if (nameOK == true)
        {
            Debug.Log("問題を出す");
            interviewerText.text = "それでは" + inputUsernameText.text + "さん、質問です";
            Destroy(this.gameObject);
            Destroy(interviewerText);

            Instantiate(questionOJT, new Vector3(540.0f, 960.0f, 0f), Quaternion.identity);
        }
    }
}
