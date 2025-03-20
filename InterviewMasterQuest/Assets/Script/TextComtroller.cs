using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

/// <summary>
/// �e�L�X�g���Ǘ�����N���X
/// </summary>
public class TextComtroller : MonoBehaviour
{
    int textNum = 0, count = 0;

    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] TextAsset TextFileA;

    List<string[]> TextData = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        StringReader reader = new StringReader(TextFileA.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            TextData.Add(line.Split(','));
        }
    }

    // Update is called once per frame
    void Update()
    {
        string Times = TextData[textNum][count].ToString();

        if (Times != "ENDTEXT")
        {
            if (Times != "END")
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    count++;
                }

                Text.text = Times; //Text�ɓ���܂��B
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    count = 0; //��i���ځj�����Z�b�g����
                    textNum++; //�s�����i���j�ɂ���
                }
            }
        }
    }

    public void QuestionStart()
    {

    }
}
