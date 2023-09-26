using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleMonsterController : MonsterController
{
    [SerializeField] float speedChasing;

    // Update is called once per frame
    protected override void Update()
    {
        switch (monsterState)
        {
            case MonsterState.Idle:
                TriggerAnim((int)MonsterAnim.Idle);
                break;
            case MonsterState.MovingToTarget:
                TriggerAnim((int)MonsterAnim.Run);
                MovingToTarget(moveSpeed);
                break;
            case MonsterState.Hit:
                TriggerAnim((int)MonsterAnim.Hit);
                break;
            case MonsterState.UseSkill:
                MovingToTarget(moveSpeed * speedChasing);
                break;
            default:
                break;
        }
    }
}
