using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    /// <summary>
    /// OpeningÅ®Main
    /// </summary>
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// MainÅ®Select
    /// </summary>
    public void LoadSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    /// <summary>
    /// SelectÅ®Question
    /// </summary>
    public void LoadQuestionScene()
    {
        SceneManager.LoadScene("QuestionScene");
    }

    /// <summary>
    /// QuestionÅ®Result
    /// </summary>
    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    /// <summary>
    /// MainÅ®Tutorial
    /// </summary>
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    /// <summary>
    /// MainÅ®Ranking
    /// </summary>
    public void LoadRankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }

    /// <summary>
    /// MainÅ®ResultList
    /// </summary>
    public void LoadResultListScene()
    {
        SceneManager.LoadScene("ResultListScene");
    }

    /// <summary>
    /// MainÅ®Ranking
    /// </summary>
    public void LoadAAAScene()
    {
        SceneManager.LoadScene("Scene");
    }
}
