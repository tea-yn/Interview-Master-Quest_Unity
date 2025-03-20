using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionLoader : MonoBehaviour
{
    public TextMeshProUGUI questionText;      // 質問を表示するText
    public Button[] answerButtons; // 答えのボタン（複数ボタンを配列で設定）
    public TextAsset jsonFile;     // JSONファイル
    public float delayBeforeNextQuestionTime = 2f; // 反応表示後に次の質問に進むまでの時間（秒）

    [SerializeField] private SceneChangeManager sceneChanger; // Inspectorでセットする

    [System.Serializable]
    public class Choice
    {
        public string text;    // 選択肢のテキスト
        public int score;      // 選択肢に対するスコア
        public string reaction; // 選択肢に対する反応
    }


    [System.Serializable]
    public class Question
    {
        public int id;          // 質問のID
        public string question; // 質問文
        public Choice[] choices; // 選択肢
    }

    [System.Serializable]
    public class QuestionList
    {
        public Question[] questions; // 複数の問題
    }

    public QuestionList quizData;
    private int currentQuestionIndex = 0; // 現在の問題のインデックス
    private int totalScore = 0;            // ユーザーのスコア

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
            // JSONファイルを読み込んで問題データを解析
            quizData = JsonUtility.FromJson<QuestionList>(jsonFile.text);
            Debug.Log("Jsonファイルを読み込み : " + quizData);

            // 最初の問題を表示
            DisplayQuestion();
        }
        else
        {
            Debug.LogError("JSONファイルがありません");
        }
    }

    void DisplayQuestion()
    {
        // 現在の問題を取得
        Question currentQuestion = quizData.questions[currentQuestionIndex];

        // 質問のテキストを表示
        questionText.text = currentQuestion.question;

        // 各ボタンに選択肢を設定
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.choices.Length)
            {
                // ボタンのテキストを設定
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.choices[i].text;

                // ボタンにクリックイベントを設定
                int index = i; // ローカル変数に保持しないと、ループ内での参照エラーが発生するので
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
                answerButtons[i].gameObject.SetActive(true); // ボタンを表示
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); // ボタンを非表示
            }
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        // 現在の問題を取得
        Question currentQuestion = quizData.questions[currentQuestionIndex];

        // 選択肢のスコアと反応を表示
        Choice selectedChoice = currentQuestion.choices[selectedIndex];
        totalScore += selectedChoice.score; // スコアを加算
        questionText.text = selectedChoice.reaction; // 反応を表示
        Debug.Log("回答に対する面接官の反応: " + questionText.text);
        Debug.Log("現在のスコア: " + totalScore);

        // 一定時間後に次の問題へ
        StartCoroutine(WaitAndLoadNextQuestion());
    }
 
    IEnumerator WaitAndLoadNextQuestion()
    {
        yield return new WaitForSeconds(delayBeforeNextQuestionTime);

        // 次の問題へ
        currentQuestionIndex++;
        if (currentQuestionIndex < quizData.questions.Length)
        {
            // 次の問題があれば、再度表示
            DisplayQuestion();
        }
        else
        {
            // 全問終了
            Debug.Log("面接終了！");
            ScoreManager.Instance.AddScore(totalScore);
            Debug.Log("最終スコア: " + totalScore);
            //ここでResultSceneに遷移
            sceneChanger.LoadResultScene();
        }
    }

    
}
