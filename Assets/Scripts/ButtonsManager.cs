using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        // 効果音
        AudioManager.Instance.PlaySFX("Button");

        SceneManager.LoadScene(SceneName);
    }

    public static void QuitGame()
    {
        // 効果音
        AudioManager.Instance.PlaySFX("Button");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ゲームプレイ終了
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// 今いるキャンバスを無効化して、別のキャンバスを有効化する
    /// </summary>
    public static void ChangeCanvas(string CanvasName)
    {
        // 効果音
        AudioManager.Instance.PlaySFX("Button");

        // ボタンが所属しているキャンバスを無効化
        GameObject currentCanvas = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.root.gameObject;
        currentCanvas.GetComponent<Canvas>().enabled = false;

        // 指定されたキャンバスを有効化
        GameObject targetCanvas = GameObject.Find(CanvasName);

        if (targetCanvas != null)
        {
            targetCanvas.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            Debug.LogError("Canvas with name " + CanvasName + " not found!");
        }
    }

    /// <summary>
    /// 使用するダイバーシティセットを変更する
    /// </summary>
    /// <param name="setNumber">ダイバーシティセットの番号</param>
    public static void ChangeDiversitySet(int setNumber)
    {
        ScoreManager.Instance.DiversitySet = setNumber;
    }


}
