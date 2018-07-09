using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class Demo1Context : MVCSContext {
    public Demo1Context(MonoBehaviour view) : base(view) { }
    protected override void mapBindings()//进行绑定映射
    {
        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        
        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//表示这个对象只会在整个工程中生成一个

        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成view和mediator的绑定

        //创建一个StratCommand开始命令    绑定开始事件
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
