using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleMonsterController : MonsterController
{
    // [SerializeField]
    float speedChasing = 10.0f;
    // [SerializeField]
    float timeChasing = 2.0f;

    // [SerializeField]
    float minDistanceNotChase = 4.0f;
    // [SerializeField]
    float maxDistanceGoChase = 6.0f;


    Timer timerChasing;

    protected override void Start()
    {
        base.Start();
        timerChasing = new Timer();
        timerChasing.SetDuration(timeChasing);
    }

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

        if (timerChasing.IsDone())
        {
            if (monsterState == MonsterState.UseSkill)
                monsterState = MonsterState.Idle;
        }
        else
        {
            timerChasing.Update(Time.deltaTime);
        }
    }

    protected void MovingToTarget(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, mtarget.transform.position, speed * Time.deltaTime);
        Vector3 lookDir = mtarget.transform.position - transform.position;
        if (lookDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookDir);

        float distance = Vector3.Distance(mtarget.transform.position, transform.position);
        if (distance > minDistanceNotChase && distance < maxDistanceGoChase)
        {
            monsterState = MonsterState.UseSkill;
            timerChasing.Reset();
        }
    }
}
