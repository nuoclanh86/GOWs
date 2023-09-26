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
            case MonsterState.ChaseTarget:
                TriggerAnim((int)MonsterAnim.Run);
                MovingToTarget(moveSpeed);
                break;
            case MonsterState.UseSkill:
                MovingToTarget(moveSpeed * speedChasing);
                break;
            case MonsterState.Die:
                break;
            default:
                break;
        }
    }

    protected void MovingToTarget(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, mtarget.transform.position, speed * Time.deltaTime);
        Vector3 lookDir = mtarget.transform.position - transform.position;
        if (lookDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookDir);
    }
}
