using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityroom.Api;

public class RankingUnityRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int currentScore = ScoreManager.Instance.Score;
        int newRecord = scoreUpdateToUnityRoom(currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int scoreUpdateToUnityRoom(int currentScore = 0)
    {
        UnityroomApiClient.Instance.SendScore(1, currentScore,ScoreboardWriteMode.HighScoreDesc);
        return 0;
    }
}
