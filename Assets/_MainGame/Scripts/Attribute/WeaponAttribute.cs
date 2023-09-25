using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttribute : ItemAttribute
{
    private bool isItemActive = false;
    private float mCooldown;
    private float mAngleHit;

    protected override void Start()
    {
        base.Start();
        mCooldown = ((MeeleWeaponScriptableObject)attributeSO).cooldownAttribute;
        mAngleHit = ((MeeleWeaponScriptableObject)attributeSO).angleHit;
    }
    protected override void Update()
    {

    }

    public void SetItemActive(bool val)
    {
        isItemActive = true;
    }
}
