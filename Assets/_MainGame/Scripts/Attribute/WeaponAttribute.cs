using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttribute : ItemAttribute
{
    enum WeaponState
    {
        Idle,
        DoingHit
    }

    private bool isItemActive = false;
    private float mCooldown;
    private float mAngleHit;
    Timer cooldownTimer;
    WeaponState weaponState;

    protected override void Start()
    {
        base.Start();
        mCooldown = ((MeeleWeaponScriptableObject)attributeSO).cooldownAttribute;
        mAngleHit = ((MeeleWeaponScriptableObject)attributeSO).angleHit;

        cooldownTimer = new Timer();
        cooldownTimer.SetDuration(mCooldown);
        weaponState = WeaponState.Idle;
    }
    protected override void Update()
    {
        if (isItemActive)
        {
            if (cooldownTimer.IsDone())
            {
                cooldownTimer.Reset();
                weaponState = WeaponState.DoingHit;
                this.gameObject.SetActive(true);
            }
            else
            {
                cooldownTimer.Update(Time.deltaTime);
            }
        }

        switch (weaponState)
        {
            case WeaponState.Idle:
                break;
            case WeaponState.DoingHit:
                break;
            default:
                break;
        }
    }

    public void SetItemActive(bool val)
    {
        isItemActive = true;
    }
}
