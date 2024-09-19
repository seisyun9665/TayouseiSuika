using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityroom.Api;

public class RankingUnityRoom : MonoBehaviour
{
    void Start()
    {
        int currentScore = ScoreManager.Instance.Score;
        scoreUpdateToUnityRoom(currentScore);
    }

    void Update()
    {
        
    }

    private void scoreUpdateToUnityRoom(int currentScore = 0)
    {
        UnityroomApiClient.Instance.SendScore(1, currentScore,ScoreboardWriteMode.HighScoreDesc);
    }
}
