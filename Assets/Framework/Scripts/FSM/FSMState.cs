using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 状态转换条件
/// </summary>
public enum Transition
{
    NullTransition=0,
    SawPlayer = 1,
    LostPlayer = 2,
}
/// <summary>
/// 状态ID，是每一个状态的唯一表示，一个状态有一个stateid，而且跟其他的状态不可以重复
/// </summary>
public enum StateID
{
    NullStateID=0,
    Patrol = 1,
    Chase = 2,
}
/// <summary>
/// 状态机状态抽象类
/// </summary>
public abstract class FSMState {
    protected StateID stateID;
    public StateID ID
    {
        get { return stateID; }
    }
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public FSMSystem fsm;
    /// <summary>
    /// 添加转换条件与对应状态
    /// </summary>
    /// <param name="transition"></param>
    /// <param name="id"></param>
    public void AddTransition(Transition transition,StateID id)
    {
        if (transition == Transition.NullTransition || id == StateID.NullStateID)
        {
            Debug.LogError("Transition or stateid is null!");
            return;
        }
        if (map.ContainsKey(transition))
        {
            Debug.LogError("State: "+stateID+" is already has transition "+transition);
            return;
        }
        map.Add(transition,id);
    }
    /// <summary>
    /// 移除转化条件
    /// </summary>
    /// <param name="transition"></param>
    public void RemoveTransition(Transition transition)
    {
        if (map.ContainsKey(transition))
        {
            Debug.LogWarning("The Transition "+transition+" you want to remove is not exit in map!");
        }
        map.Remove(transition);
    }
    /// <summary>
    /// 根据转换条件得到将要转换的状态
    /// </summary>
    /// <param name="transition"></param>
    /// <returns></returns>
    public StateID GetOutputState(Transition transition)
    {
        if (map.ContainsKey(transition))
        {
            return map[transition];
        }
        return StateID.NullStateID;
    }
    /// <summary>
    /// 进入当前状态需要做的事
    /// </summary>
    public virtual void DoBeforeEntering() { }
    /// <summary>
    /// 离开当前状态需要做的事
    /// </summary>
    public virtual void DoBeforeLeaving() { }
    /// <summary>
    /// 处于当前状态每一帧要做的事
    /// </summary>
    public abstract void DoUpdate();
}
