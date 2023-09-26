using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAttribute : CharAttribute
{
    Slider hpBar;
    [SerializeField] MonsterController monsterController;

    protected override void Start()
    {
        base.Start();
        hpBar = this.GetComponentInChildren<Slider>();
        hpBar.value = 1.0f;
        hpBar.gameObject.SetActive(false);
    }

    protected override void UpdateHPBar()
    {
        // Debug.Log("UpdateHPBar : " + curHealth + " / " + health);
        hpBar.gameObject.SetActive(true);
        if (curHealth <= 0)
        {
            curHealth = 0;
            hpBar.gameObject.SetActive(false);
            TriggerCharacterDead();
            ActionPhaseManager.GetInstance().UpdateTotalMonsterOnScreen(-1);
        }
        hpBar.value = (float)curHealth / health;
    }

    protected override void TriggerCharacterDead()
    {
        ActionPhaseManager.GetInstance().UpdateMonsterKilled();
        monsterController.MonsterDead();
        // this.gameObject.SetActive(false);
    }
}