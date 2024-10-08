using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ダイバーシティ選択機能</summary>
public class SelectManager : MonoBehaviour
{
    /// <summary>選択中セット表示用イメージ</summary>
    public Image SelectedDiversityImage;
    /// <summary>セット名表示用テキスト</summary>
    public TMP_Text SetText;
    /// <summary>選択中ダイバーシティの番号</summary>
    private int _diversitySetIndex;

    void Start()
    {
        // さっきまで選択していたセットを読み込む
        _diversitySetIndex = DiversityManager.Instance.DiversitySetIndex;
        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityManager.Instance.SelectedDiversitySet.SetImage;
        SetText.text = DiversityManager.Instance.SelectedDiversitySet.DiversitySetName;
    }

    /// <summary>
    /// 次のセットを選択
    /// </summary>
    public void NextSet()
    {
        _diversitySetIndex++;
        if (_diversitySetIndex >= DiversityManager.Instance.DiversitySetList.Length)
        {
            // 最後まで行ったら最初に戻る
            _diversitySetIndex = 0;

        }
        DiversityManager.Instance.DiversitySetIndex = _diversitySetIndex;

        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityManager.Instance.SelectedDiversitySet.SetImage;
        // 表示名変更
        SetText.text = DiversityManager.Instance.SelectedDiversitySet.DiversitySetName;
    }

    public void PreviousSet()
    {
        _diversitySetIndex--;
        if (_diversitySetIndex < 0)
        {
            // 1番目選択中に後ろに飛んだら最後を表示する
            _diversitySetIndex = DiversityManager.Instance.DiversitySetList.Length - 1;
        }
        DiversityManager.Instance.DiversitySetIndex = _diversitySetIndex;

        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityManager.Instance.SelectedDiversitySet.SetImage;
        // 表示名変更
        SetText.text = DiversityManager.Instance.SelectedDiversitySet.DiversitySetName;
    }
}
