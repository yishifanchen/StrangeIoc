using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 音效管理器
/// </summary>
public class AudioManager
{
    //static 静态  const是常量
    private static string audioTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private const string audioTextPathMiddle = "AudioList";
    private const string audioTextPathPostfix = ".txt";
    public static string AudioTextPath
    {
        get
        {
            return audioTextPathPrefix + audioTextPathMiddle + audioTextPathPostfix;
        }
    }
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();
    /// <summary>
    /// 是否静音
    /// </summary>
    public bool isMute = false;
    public void Init()
    {
        LoadAudioClip();
    }
    void LoadAudioClip()
    {
        audioClipDict = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMiddle);
        string[] lines = ta.ToString().Split('\n');
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalues = line.Split(':');
            string key = keyvalues[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalues[1]);
            audioClipDict.Add(key,value);
        }
    }
    public void Play(string name)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }
    public void Play(string name,Vector3 position)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
