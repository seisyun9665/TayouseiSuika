using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    /// <summary>全アセット</summary>
    public Sprite[] DiversityAssets;
    /// <summary>選択中アセット表示用イメージ</summary>
    public Image SelectedDiversityImage;

    void Start()
    {
        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityAssets[ScoreManager.Instance.DiversitySet];
    }

    public void NextSet()
    {
        int _diversitySetIndex = ScoreManager.Instance.DiversitySet;
        _diversitySetIndex++;
        if (_diversitySetIndex >= DiversityAssets.Length)
        {
            _diversitySetIndex = 0;
        }

        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityAssets[ScoreManager.Instance.DiversitySet];

        ScoreManager.Instance.DiversitySet = _diversitySetIndex;
    }

    public void PreviousSet()
    {
        int _diversitySetIndex = ScoreManager.Instance.DiversitySet;
        _diversitySetIndex--;
        if (_diversitySetIndex < 0)
        {
            _diversitySetIndex = DiversityAssets.Length - 1;
        }

        // 選択中のダイバーシティーセットの画像に差し替え
        SelectedDiversityImage.sprite = DiversityAssets[ScoreManager.Instance.DiversitySet];

        ScoreManager.Instance.DiversitySet = _diversitySetIndex;
    }

}
