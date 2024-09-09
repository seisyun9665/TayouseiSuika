using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    /// <summary>ランキング最大順位</summary>
    public static int MaxRankSaved = 5;
    /// <summary>スコア保存時の変数名の先頭。PrefsScoreName + 順位 で保存される</summary>
    private static string PrefsScoreName = "HighScore";

    void Start()
    {
        int rank = JudgeHighScore(ScoreManager.Instance.Score); // スコアの順位。ランキング圏外は-1
        UpdateRanking();
    }

    /// <summary>
    /// ハイスコア取得
    /// </summary>
    /// <returns>上位五番目までのハイスコア</returns>
    int[] GetHighScores()
    {
        int[] scores = new int[MaxRankSaved];

        for (int i = 0; i < MaxRankSaved; i++)
        {
            scores[i] = PlayerPrefs.GetInt(PrefsScoreName + i.ToString(), 0);
        }

        return scores;
    }

    /// <summary>
    /// ハイスコア更新
    /// </summary>
    /// <param name="score"></param>
    /// <returns>順位。ランキング外は-1を返す。</returns>
    int JudgeHighScore(int score)
    {
        // 現ランキング取得
        int[] scores = GetHighScores();

        // 新しいスコアを一時配列に追加（配列長+1）
        List<int> scoreList = new List<int>(scores);
        scoreList.Add(score);
        scoreList.Sort((a, b) => b.CompareTo(a));  // 降順ソート

        // 入力されたscoreの順位を探す
        int rank = scoreList.IndexOf(score) + 1; // 1-based index
        if (rank > MaxRankSaved)
        {
            return -1;  // ランキング圏外
        }

        // ランキング更新した場合の処理
        int[] newScores = scoreList.GetRange(0, Mathf.Min(MaxRankSaved, scoreList.Count)).ToArray();
        SetScores(newScores);

        // 順位を返す（1-based indexで返す）
        return rank;
    }

    /// <summary>
    /// 配列で入力されたスコアを設定
    /// </summary>
    /// <param name="scores">スコア配列</param>
    void SetScores(int[] scores)
    {
        for (int i = 0; i < MaxRankSaved && i < scores.Length; i++)
        {
            PlayerPrefs.SetInt(PrefsScoreName + i.ToString(), scores[i]);
        }
    }

    /// <summary>
    /// ランキング情報を更新する
    /// </summary>
    void UpdateRanking()
    {
        int[] scores = GetHighScores();
        string rankingText = "";

        // スコアの順位ごとにフォーマットして文字列を作成
        for (int i = 0; i < scores.Length; i++)
        {
            // 1位から順に "1位: スコア" の形で表示
            rankingText += (i + 1).ToString() + ". " + scores[i].ToString() + " Point\n";
        }

        // 作成した文字列を表示
        this.gameObject.GetComponent<TMP_Text>().text = rankingText;
    }

    /// <summary>
    /// ランキングをスコア0で上書き
    /// </summary>
    void ResetRanking()
    {
        // スコアをリセットする配列（全て0にする）
        int[] resetScores = new int[MaxRankSaved];

        for (int i = 0; i < MaxRankSaved; i++)
        {
            resetScores[i] = 0;  // 0でリセット
        }

        SetScores(resetScores);
        UpdateRanking();
    }
}
