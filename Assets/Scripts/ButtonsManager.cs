using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="SceneName">シーン名</param>
    public static void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ゲームプレイ終了
#else
        Application.Quit();
#endif
    }
}
