using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 国际化管理器
/// </summary>
public class LocalizationManager {
    private static LocalizationManager _isntance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = new LocalizationManager();
            }
            return _isntance;
        }
    }
    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    public static string Language = English;
    private Dictionary<string, string> dict;
    /// <summary>
    /// 构造函数
    /// </summary>
    public LocalizationManager()
    {
        dict = new Dictionary<string, string>();
        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)==false)
            {
                string[] keyvalues = line.Split('=');
                dict.Add(keyvalues[0], keyvalues[1]);
            }
        }
    }
    public void Init()
    {
        //DO nothing.
    }
    /// <summary>
    /// 获得字典中的值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
