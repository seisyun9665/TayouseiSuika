using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>シングルトンインスタンス</summary>
    private static ScoreManager instance;
    public static ScoreManager Instance
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


    /// <summary>スコア(プロパティ使用)</summary>
    private int score = 0;
    /// <summary>スコア</summary>
    public int Score
    {
        get { return score; }
        set { score = value; }
    }


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private static void SetupInstance()
    {
        instance = FindObjectOfType<ScoreManager>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "ScoreManager";
            instance = gameObj.AddComponent<ScoreManager>();
            DontDestroyOnLoad(gameObj);
        }
    }


}
