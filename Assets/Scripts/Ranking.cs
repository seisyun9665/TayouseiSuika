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

        // TODO: ハイスコア更新機能
        // ハイスコア更新後のint配列を作成して、SetScoresで値を保存する
        // その後、入力されたscoreの順位を返す
        // 同率のスコアがある場合は、同率スコア下位に挿入して順位を表示(3位で同率なら4位と表示)
        // 同率の結果MaxRankSaved未満の順位になる場合は、ランキング外で-1を返す（ランキングは更新しない）

        // ランキング外
        return -1;

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

    // ハイスコアに基づいて表示を変える
    void UpdateText(string text)
    {

        this.gameObject.GetComponent<TMP_Text>().text = text;
    }
}
