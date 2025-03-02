using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ButtonColorController : MonoBehaviour
{
    [Header("キャラクター選択")]
    public CanvasGroup charaC_GP;    //キャラクターのキャンパスGP
    public Button[] charaButtonList;    //キャラクターのButtonリスト

    [Header("難易度選択")]
    public CanvasGroup diffC_GP;    //難易度のキャンパスGP
    public Button[] diffButtonList; //難易度のButtonリスト

    [Header("アルファ値設定")]
    [Range(0f, 100f)] public float selectedAlpha = 100.0f;   // 選択時のアルファ値
    [Range(0f, 100f)] public float NormalAlpha = 60.0f; // 非選択時のアルファ値

     // Start is called before the first frame update
    void Start()
    {
        SetGroupAlpha(charaC_GP, false);  // キャラクター選択グループ 初期状態: 薄くする
        SetGroupAlpha(diffC_GP, false); // 難易度選択グループ 初期状態: 薄くする
    }

    // キャラクター選択グループが選択された時
    public void OnCharacterGroupSelected()
    {
        SetGroupAlpha(charaC_GP, true);   // キャラクター選択グループ 濃くする
        SetGroupAlpha(diffC_GP, false);  // 難易度選択グループ 薄くする

        //tButtonInteractable(charaButtonList, true);    // キャラクター選択グループのボタンをインタラクティブに
        //SetButtonInteractable(diffButtonList, false);   // 難易度選択グループのボタンを非インタラクティブに
    }

    // 難易度選択グループが選択された時
    public void OnDifficultyGroupSelected()
    {
        SetGroupAlpha(charaC_GP, false);  // キャラクター選択グループ 薄くする
        SetGroupAlpha(diffC_GP, true);   // 難易度選択グループ 濃くする

        //SetButtonInteractable(charaButtonList, false);   // キャラクター選択グループのボタンを非インタラクティブに
        //SetButtonInteractable(diffButtonList, true);    // 難易度選択グループのボタンをインタラクティブに
    }

    // CanvasGroupのアルファ値を設定し、インタラクティブ状態も必要に応じて設定する関数
    private void SetGroupAlpha(CanvasGroup canvasGroup, bool isSelected)
    {
        canvasGroup.alpha = isSelected ? selectedAlpha : NormalAlpha; // 選択状態によってアルファ値を変更
        canvasGroup.interactable = isSelected; // グループが選択されている時のみインタラクティブにする (必要に応じて)
        canvasGroup.blocksRaycasts = isSelected; // グループが選択されている時のみ Raycast をブロックする (必要に応じて)
    }

    /*
    // ボタンのインタラクティブ状態をグループ単位で設定する関数
    private void SetButtonInteractable(Button[] buttons, bool isInteractable)
    {
        foreach (Button button in buttons)
        {
            button.interactable = isInteractable;
        }
    }*/
}
