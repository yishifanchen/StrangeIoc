using UnityEngine;
using System.Collections;
/// <summary>
/// 追逐状态
/// </summary>
public class ChaseState : FSMState
{
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;
    public ChaseState(GameObject npc,GameObject player)
    {
        stateID = StateID.Chase;
        this.npc = npc;
        npcRd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }
    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state "+ID);
    }
    public override void DoUpdate()
    {
        CheckTransition();
        ChaseMove();
    }
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) > 20)
        {
            fsm.PreformTransition(Transition.LostPlayer);
        }
    }
    private void ChaseMove()
    {
        npcRd.velocity = npc.transform.forward * 5;
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = player.transform.position.y;
        npc.transform.LookAt(targetPosition);
    }
}
