using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ダイバーシティセットの選択・非選択をゲーム全体で管理するスクリプト
// DiversitySetIndexで、使用するダイバーシティセットを選択してから、SelectedDiversitySetObjectsで本体を取り出す
public class DiversityManager : MonoBehaviour
{
    /// <summary>ダイバーシティセットのリスト</summary>
    public GameObject[] DiversitySetList;
    /// <summary>使用するダイバーシティのリスト</summary>
    public DiversitySet SelectedDiversitySet
    {
        get { return DiversitySetList[_diversitySetIndex].GetComponent<DiversitySet>(); }
    }

    /// <summary>インゲームで選択されているダイバーシティセットの番号</summary>
    private int _diversitySetIndex = 0;
    public int DiversitySetIndex
    {
        get { return _diversitySetIndex; }
        set { _diversitySetIndex = value; }
    }

    /// <summary>シングルトンインスタンス</summary>
    private static DiversityManager instance;
    public static DiversityManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            _diversitySetIndex = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private static void SetupInstance()
    {
        instance = FindObjectOfType<DiversityManager>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "DiversityManager";
            instance = gameObj.AddComponent<DiversityManager>();
            DontDestroyOnLoad(gameObj);
        }
    }


}
