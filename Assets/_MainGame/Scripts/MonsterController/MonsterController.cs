using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    protected enum MonsterState
    {
        Idle,
        ChaseTarget,
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
    protected GameObject mtarget = null;
    protected MonsterState monsterState;
    protected float moveSpeed;

    [SerializeField] float disableMonsterDeadDelay = 2.0f;
    protected Collider colliderMonster;

    // Start is called before the first frame update
    void Start()
    {
        mtarget = null;
        monsterState = MonsterState.Idle;
        monsterAttribute = this.GetComponent<MonsterAttribute>();
        animatorMonster = this.GetComponent<Animator>();
        colliderMonster = this.GetComponent<Collider>();
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
            case MonsterState.ChaseTarget:
                TriggerAnim((int)MonsterAnim.Run);
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
        monsterState = MonsterState.ChaseTarget;
    }
    public void DeleteTarget()
    {
        mtarget = null;
        monsterState = MonsterState.Idle;
    }

    public void TriggerAnim(int animIndex)
    {
        animatorMonster.SetInteger("AnimIndex", animIndex);
    }
    public void MonsterDead()
    {
        colliderMonster.enabled = false;
        monsterState = MonsterState.Die;
        TriggerAnim((int)MonsterAnim.Die);
        GameObject go = this.gameObject;
        // MonstersManager.GetInstance().monstersDeadList.Add(go);
        StartCoroutine(DisableMonsterDead(disableMonsterDeadDelay));
    }

    IEnumerator DisableMonsterDead(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }

    public void RebornMonster()
    {
        colliderMonster.enabled = true;
        monsterState = MonsterState.Idle;
    }
}
