﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using strange.extensions.context.api;

public class CubeMediator : Mediator {
    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局的派发器
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        cubeView.Init();
        Debug.Log("OnRegister");
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);

        //通过dispatcher 发起请求分数的命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }

    private void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
    private void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)(evt.data));
    }
}
