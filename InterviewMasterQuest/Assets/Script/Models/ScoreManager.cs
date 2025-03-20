using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Score��Model
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int TotalScore { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��j������Ȃ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        TotalScore += score;
    }

    public void ResetScore()
    {
        TotalScore = 0;
    }
}
