using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class RequestScoreCommand : EventCommand {
    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreService.RequestScore("http://xx/xxx/xxx");
    }
    private void OnComplete(IEvent evt)
    {
        Debug.Log("Request score OnComplete" + evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);
        Release();
    }
}
