using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選択結果の保存など
/// </summary>
public class SelectManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSelectWomen()
    {
        Debug.Log("女性を選択");
    }

    public void CharacterSelectMan()
    {
        Debug.Log("男性を選択");
    }

    public void CompanySelect1()
    {
        Debug.Log("中小企業を選択");
    }

    public void CompanySelect2()
    {
        Debug.Log("大手企業を選択");
    }

}
