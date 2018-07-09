using UnityEngine;
using System.Collections;
/// <summary>
/// 巡逻状态
/// </summary>
public class PatrolState : FSMState
{
    private int targetWaypoint;
    private Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;
    public PatrolState(Transform[] wp,GameObject npc,GameObject player)
    {
        stateID = StateID.Patrol;
        waypoints = wp;
        this.player = player;
        this.npc = npc;
        npcRd = npc.GetComponent<Rigidbody>();
        targetWaypoint = 0;
    }
    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state "+ID);
    }
    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < 10)
        {
            fsm.PreformTransition(Transition.SawPlayer);
        }
    }
    private void PatrolMove()
    {
        npcRd.velocity = npc.transform.forward * 3;
        Transform targetTrans = waypoints[targetWaypoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWaypoint++;
            targetWaypoint %= waypoints.Length;
        }
    }
}
