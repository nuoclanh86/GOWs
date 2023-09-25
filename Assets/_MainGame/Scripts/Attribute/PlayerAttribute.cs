using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharAttribute
{
    public List<GameObject> tempLoadedItems;

    protected override void Start()
    {
        base.Start();
        foreach (GameObject i in tempLoadedItems)
        {
            AddItemToChar(i);
        }
    }

    protected override void UpdateHPBar()
    {
        Debug.Log("UpdateHPBar : " + curHealth + " / " + health);
        if (curHealth <= 0)
        {
            curHealth = 0;
            TriggerCharacterDead();
        }
        ActionPhaseManager.GetInstance().UpdateHPMainPlayerBar((float)curHealth / health);
    }

    protected override void TriggerCharacterDead()
    {
        ActionPhaseManager.GetInstance().PauseGame(true);
    }

    public void AddItemToChar(GameObject item)
    {
        ItemAttribute iAttribute = item.GetComponentInChildren<ItemAttribute>();
        this.AddAttributeHealth(iAttribute.GetHealth());
        // this.AddAttributeDamage(item.GetDamage());
        this.AddAttributeArmour(iAttribute.GetArmour());

        //active item
        GameObject createItem = Instantiate(item, Vector3.up, Quaternion.identity, this.transform);
        createItem.transform.localPosition = Vector3.up;
        createItem.GetComponentInChildren<WeaponAttribute>().SetItemActive(true);
    }
}
