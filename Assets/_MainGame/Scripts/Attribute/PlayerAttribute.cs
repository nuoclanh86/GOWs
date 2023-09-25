using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharAttribute
{
    public List<ItemAttribute> items;

    protected override void Start()
    {
        base.Start();
        foreach (ItemAttribute i in items)
        {

        }
    }

    protected override void UpdateHPBar()
    {
        Debug.Log("UpdateHPBar : " + curHealth + " / " + maxHealth);
        if (curHealth <= 0)
        {
            curHealth = 0;
            TriggerCharacterDead();
        }
        ActionPhaseManager.GetInstance().UpdateHPMainPlayerBar((float)curHealth / maxHealth);
    }

    protected override void TriggerCharacterDead()
    {
        ActionPhaseManager.GetInstance().PauseGame(true);
    }

    protected override void OnTriggerEnter(Collider other)
    {

    }
}
