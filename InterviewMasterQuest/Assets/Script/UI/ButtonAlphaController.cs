using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAlphaController : MonoBehaviour
{
    [Header("キャラクターButtonGP")]
    public Button[] charaButtonL; 

    [Header("難易度選択ButtonGP")]
    public Button[] diffButtonL; 

    /*
    [Header("アルファ値設定")]
    [Range(0f, 1.0f)] public float selectedAlpha = 1.0f;   // 選択時のアルファ値
    [Range(0f, 1.0f)] public float NormalAlpha = 0.6f; // 非選択時のアルファ値
    */

    private Button selectedCharaButton = null;  // グループAの現在の選択ボタン
    private Button selectedDiffButton = null;  // グループBの現在の選択ボタン


    private void Start()
    {
        foreach (Button btn in charaButtonL)
        {
            btn.onClick.AddListener(() => SelectButtonInGroup(btn, charaButtonL, ref selectedCharaButton));
        }
        foreach (Button btn in diffButtonL)
        {
            btn.onClick.AddListener(() => SelectButtonInGroup(btn, diffButtonL, ref selectedDiffButton));
        }
    }

    private void SelectButtonInGroup(Button clickedButton, Button[] groupButtons, ref Button selectedButton)
    {
        // 以前選択されていたボタンを interactable = true に戻す
        if (selectedButton != null)
        {
            selectedButton.interactable = true;
        }

        // 新しく押されたボタンを選択状態にする
        selectedButton = clickedButton;
        selectedButton.interactable = false; // これにより SelectedColor が適用される
    }
}