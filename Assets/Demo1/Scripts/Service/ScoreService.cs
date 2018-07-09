using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ScoreService : IScoreService
{
    public void RequestScore(string url)
    {
        Debug.Log("Requset score from url:" + url);
        OnReceiveScore();
    }
    public void OnReceiveScore()
    {
        int score = Random.Range(0, 10);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);
    }
    public void UpdateScore(string url,int score)
    {
        Debug.Log("Update score to url : " + url + "UpdateScore:" + score);
    }
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
}
