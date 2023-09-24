using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : Attribute
{
    protected override void UpdateHPBar()
    {
        Debug.Log("UpdateHPBar : " + curHealth + " / " + maxHealth);
        ActionPhaseManager.GetInstance().UpdateHPMainPlayerBar((float)curHealth / maxHealth);
    }
}
