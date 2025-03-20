using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionLoader : MonoBehaviour
{
    public TextMeshProUGUI questionText;      // �����\������Text
    public Button[] answerButtons; // �����̃{�^���i�����{�^����z��Őݒ�j
    public TextAsset jsonFile;     // JSON�t�@�C��
    public float delayBeforeNextQuestionTime = 2f; // �����\����Ɏ��̎���ɐi�ނ܂ł̎��ԁi�b�j

    [SerializeField] private SceneChangeManager sceneChanger; // Inspector�ŃZ�b�g����

    [System.Serializable]
    public class Choice
    {
        public string text;    // �I�����̃e�L�X�g
        public int score;      // �I�����ɑ΂���X�R�A
        public string reaction; // �I�����ɑ΂��锽��
    }


    [System.Serializable]
    public class Question
    {
        public int id;          // �����ID
        public string question; // ���╶
        public Choice[] choices; // �I����
    }

    [System.Serializable]
    public class QuestionList
    {
        public Question[] questions; // �����̖��
    }

    public QuestionList quizData;
    private int currentQuestionIndex = 0; // ���݂̖��̃C���f�b�N�X
    private int totalScore = 0;            // ���[�U�[�̃X�R�A

    /// <summary>
    /// Getter
    /// </summary>
    /// <returns></returns>
    public int GetTotalScore()
    {
        return this.totalScore;
    }

    void Start()
    {
        if (jsonFile != null)
        {
            // JSON�t�@�C����ǂݍ���Ŗ��f�[�^�����
            quizData = JsonUtility.FromJson<QuestionList>(jsonFile.text);
            Debug.Log("Json�t�@�C����ǂݍ��� : " + quizData);

            // �ŏ��̖���\��
            DisplayQuestion();
        }
        else
        {
            Debug.LogError("JSON�t�@�C��������܂���");
        }
    }

    void DisplayQuestion()
    {
        // ���݂̖����擾
        Question currentQuestion = quizData.questions[currentQuestionIndex];

        // ����̃e�L�X�g��\��
        questionText.text = currentQuestion.question;

        // �e�{�^���ɑI������ݒ�
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.choices.Length)
            {
                // �{�^���̃e�L�X�g��ݒ�
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.choices[i].text;

                // �{�^���ɃN���b�N�C�x���g��ݒ�
                int index = i; // ���[�J���ϐ��ɕێ����Ȃ��ƁA���[�v���ł̎Q�ƃG���[����������̂�
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
                answerButtons[i].gameObject.SetActive(true); // �{�^����\��
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); // �{�^�����\��
            }
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        // ���݂̖����擾
        Question currentQuestion = quizData.questions[currentQuestionIndex];

        // �I�����̃X�R�A�Ɣ�����\��
        Choice selectedChoice = currentQuestion.choices[selectedIndex];
        totalScore += selectedChoice.score; // �X�R�A�����Z
        questionText.text = selectedChoice.reaction; // ������\��
        Debug.Log("�񓚂ɑ΂���ʐڊ��̔���: " + questionText.text);
        Debug.Log("���݂̃X�R�A: " + totalScore);

        // ��莞�Ԍ�Ɏ��̖���
        StartCoroutine(WaitAndLoadNextQuestion());
    }
 
    IEnumerator WaitAndLoadNextQuestion()
    {
        yield return new WaitForSeconds(delayBeforeNextQuestionTime);

        // ���̖���
        currentQuestionIndex++;
        if (currentQuestionIndex < quizData.questions.Length)
        {
            // ���̖�肪����΁A�ēx�\��
            DisplayQuestion();
        }
        else
        {
            // �S��I��
            Debug.Log("�ʐڏI���I");
            ScoreManager.Instance.AddScore(totalScore);
            Debug.Log("�ŏI�X�R�A: " + totalScore);
            //������ResultScene�ɑJ��
            sceneChanger.LoadResultScene();
        }
    }

    
}
