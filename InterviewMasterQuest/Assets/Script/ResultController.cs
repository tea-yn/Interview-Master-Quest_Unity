using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using QuestionLoader;

public class ResultController : MonoBehaviour
{
    private int finalScore;
    [SerializeField]private TextMeshProUGUI fainalScoreText;

    [SerializeField] private QuestionLoader questionLoader; // Inspector�ŃZ�b�g����

    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreManager.Instance.TotalScore;
        fainalScoreText.text = finalScore.ToString();
        Debug.Log("�ŏI�X�R�A: "�@+ finalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
