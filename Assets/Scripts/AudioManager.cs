using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>シングルトンインスタンス</summary>
    private static AudioManager instance;
    public static AudioManager Instance
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
        }
        else
        {
            Destroy(this.gameObject);
        }

        // BGM再生
        PlayMusic("Theme");
    }


    /// <summary>
    /// シングルトンインスタンス初期化処理
    /// </summary>
    private static void SetupInstance()
    {
        instance = FindObjectOfType<AudioManager>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "AudioManager";
            instance = gameObj.AddComponent<AudioManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

    /// <summary>BGM音源の配列</summary>
    public Sound[] musicSounds, sfxSounds;
    /// <summary>効果音の配列</summary>
    public AudioSource musicSource, sfxSource;

    /// <summary>
    /// BGMを鳴らす
    /// </summary>
    /// <param name="name">BGM名</param>
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    /// <summary>
    /// 効果音を鳴らす
    /// </summary>
    /// <param name="name">効果音名</param>
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

}
