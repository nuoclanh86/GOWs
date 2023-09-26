using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    protected enum MonsterState
    {
        Idle,
        MovingToTarget,
        Hit,
        UseSkill,
        Die
    }

    protected enum MonsterAnim
    {
        Idle = 0,
        Run,
        Hit,
        Die
    }

    Animator animatorMonster;
    MonsterAttribute monsterAttribute;
    GameObject mtarget = null;
    protected MonsterState monsterState;
    protected float moveSpeed;

    [SerializeField] float disableMonsterDeadDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        mtarget = null;
        monsterState = MonsterState.Idle;
        monsterAttribute = this.GetComponent<MonsterAttribute>();
        animatorMonster = this.GetComponent<Animator>();
        moveSpeed = monsterAttribute.GetMovementSpeed();

        SetTarget(ActionPhaseManager.GetInstance().GetMainPlayer());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        switch (monsterState)
        {
            case MonsterState.Idle:
                TriggerAnim((int)MonsterAnim.Idle);
                break;
            case MonsterState.MovingToTarget:
                TriggerAnim((int)MonsterAnim.Run);
                break;
            case MonsterState.Hit:
                TriggerAnim((int)MonsterAnim.Hit);
                break;
            case MonsterState.Die:
                break;
            case MonsterState.UseSkill:
                break;
            default:
                break;
        }
    }

    public void SetTarget(GameObject target)
    {
        mtarget = target;
        monsterState = MonsterState.MovingToTarget;
    }
    public void DeleteTarget()
    {
        mtarget = null;
        monsterState = MonsterState.Idle;
    }
    protected void MovingToTarget(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, mtarget.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(mtarget.transform.position - transform.position);
    }
    public void TriggerAnim(int animIndex)
    {
        animatorMonster.SetInteger("AnimIndex", animIndex);
    }
    public void MonsterDead()
    {
        monsterState = MonsterState.Die;
        TriggerAnim((int)MonsterAnim.Die);
        StartCoroutine(DisableMonsterDead(disableMonsterDeadDelay));
    }

    IEnumerator DisableMonsterDead(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
