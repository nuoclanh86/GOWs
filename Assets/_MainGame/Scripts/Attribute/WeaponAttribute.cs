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

    float angleCount, mSpeedRotate, defaultSpeedRotate = 10.0f;
    float fromAngle = 0.0f;

    [SerializeField] GameObjectTrigger _childTrigger;

    [SerializeField] Transform meshWeapon;

    void Awake()
    {
        this._childTrigger.OnTriggerColliderEnter += this.OnWeaponTriggerEnter;
    }
    void OnDestroy()
    {
        this._childTrigger.OnTriggerColliderEnter -= this.OnWeaponTriggerEnter;
    }

    protected override void Start()
    {
        base.Start();
        mCooldown = ((MeeleWeaponScriptableObject)attributeSO).cooldownAttribute;
        mAngleHit = ((MeeleWeaponScriptableObject)attributeSO).angleHit;
        mSpeedRotate = ((MeeleWeaponScriptableObject)attributeSO).speedRotate * defaultSpeedRotate;

        cooldownTimer = new Timer();
        cooldownTimer.SetDuration(mCooldown);
        weaponState = WeaponState.Idle;

        meshWeapon.gameObject.SetActive(false);
    }
    protected override void Update()
    {
        if (isItemActive)
        {
            if (cooldownTimer.IsDone())
            {
                StartWeaponRotateAction();
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
                DoingWeaponRotateAction();
                break;
            default:
                break;
        }
    }

    public void SetItemActive(bool val)
    {
        isItemActive = true;
    }

    void StartWeaponRotateAction()
    {
        weaponState = WeaponState.DoingHit;
        meshWeapon.gameObject.SetActive(true);
        cooldownTimer.Reset();
        angleCount = 0.0f;
        // fromAngle = Random.Range(0.0f, 360.0f);
        fromAngle = 0.0f;
    }
    void DoingWeaponRotateAction()
    {
        angleCount += Time.deltaTime * mSpeedRotate;
        // Debug.Log("DoingWeaponRotateAction : " + angleCount + " - " + mAngleHit);
        if (angleCount < mAngleHit)
        {
            this.transform.localRotation = Quaternion.AngleAxis(fromAngle + angleCount, Vector3.up);
        }
        else
        {
            weaponState = WeaponState.Idle;
            meshWeapon.gameObject.SetActive(false);
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {

    }

    public void OnWeaponTriggerEnter(GameObject thisWeapon, Collider other)
    {
        Debug.Log("OnWeaponTriggerEnter other : " + other.name + " by " + thisWeapon.name);
        if (other.tag == "Monster")
        {
            CharAttribute cA = other.GetComponent<CharAttribute>();
            cA.WasHit(this.damage);
        }
    }
}
