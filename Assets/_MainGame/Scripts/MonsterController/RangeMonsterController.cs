using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMonsterController : MonsterController
{
    // Update is called once per frame
    protected override void Update()
    {
        switch (monsterState)
        {
            case MonsterState.Idle:
                TriggerAnim((int)MonsterAnim.Idle);
                break;
            case MonsterState.ChaseTarget:
                TriggerAnim((int)MonsterAnim.Hit);
                break;
            case MonsterState.UseSkill:
                break;
            case MonsterState.Die:
                break;
            default:
                break;
        }
    }
}
