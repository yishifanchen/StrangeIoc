using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 资源池管理器
/// </summary>
public class PoolManager {
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }
    private static string poolConfigPathPrefix= "Assets/Framework/Resources/";
    private const string poolConfigPathMiddle = "GameobjectPool";
    private const string poolConfigPathPostfix = ".asset";
    public static string PoolConfigPath
    {
        get { return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix; }
    }
    private Dictionary<string, GameObjectPool> poolDict;
    /// <summary>
    /// 构造函数
    /// </summary>
    private PoolManager()
    {
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);
        poolDict = new Dictionary<string, GameObjectPool>();
        foreach(GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }
    public void Init()
    {

    }
    /// <summary>
    /// 获得实例
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if (poolDict.TryGetValue(poolName,out pool))
        {
            return pool.GetInst();
        }
        Debug.LogWarning("Pool:" + poolName + "is not exists");
        return null;
    }
}
