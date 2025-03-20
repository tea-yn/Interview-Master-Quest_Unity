using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using QuestionLoader;

public class ResultController : MonoBehaviour
{
    private int finalScore;
    [SerializeField]private TextMeshProUGUI fainalScoreText;

    [SerializeField] private QuestionLoader questionLoader; // Inspectorでセットする

    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreManager.Instance.TotalScore;
        fainalScoreText.text = finalScore.ToString();
        Debug.Log("最終スコア: "　+ finalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
