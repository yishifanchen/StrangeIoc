using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public class TestService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void OnReceiveScore()
    {
        Debug.Log("fsafdsf");
    }

    public void RequestScore(string url)
    {
        Debug.Log("fsafdsf");
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("fsafdsf");
    }
}
