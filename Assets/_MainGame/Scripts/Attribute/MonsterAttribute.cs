using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAttribute : CharAttribute
{
    Slider hpBar;

    protected override void Start()
    {
        base.Start();
        hpBar = this.GetComponentInChildren<Slider>();
        hpBar.value = 1.0f;
    }

    protected override void UpdateHPBar()
    {
        Debug.Log("UpdateHPBar : " + curHealth + " / " + health);
        if (curHealth <= 0)
        {
            curHealth = 0;
            TriggerCharacterDead();
        }
        hpBar.value = (float)curHealth / health;
    }

    protected override void TriggerCharacterDead()
    {
        this.gameObject.SetActive(false);
    }
}