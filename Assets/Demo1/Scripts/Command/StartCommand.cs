using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class StartCommand : Command {
    /// <summary>
    /// 当这个命令被执行的时候，默认会调用Execute方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("start command execute");
    }
}
