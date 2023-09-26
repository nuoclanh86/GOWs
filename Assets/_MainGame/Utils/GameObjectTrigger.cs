using UnityEngine;
using UnityEngine.Events;

public class GameObjectTrigger : MonoBehaviour
{
    // [SerializeField] bool triggerOnServerOnly = true;

    public event System.Action<GameObject, Collider> OnTriggerColliderEnter;
    // public event System.Action<GameObject, Collider> OnTriggerColliderStay;

    private void OnTriggerEnter(Collider other)
    {
        // if (triggerOnServerOnly == true && GameManager.Instance.mIsMulti && !GameNetManager.Instance.IsServerSide())
        //     return;
        // else if (triggerOnServerOnly == false && GameManager.Instance.mIsMulti && GameNetManager.Instance.IsServerSide())
        //     return;
        if (OnTriggerColliderEnter != null)
            this.OnTriggerColliderEnter.Invoke(this.gameObject, other);
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if (triggerOnServerOnly == true && GameManager.Instance.mIsMulti && !GameNetManager.Instance.IsServerSide())
    //         return;
    //     else if (triggerOnServerOnly == false && GameManager.Instance.mIsMulti && GameNetManager.Instance.IsServerSide())
    //         return;
    //     if (OnTriggerColliderStay != null)
    //         this.OnTriggerColliderStay.Invoke(this.gameObject, other);
    // }

    // void OnParticleCollision(GameObject other)
    // {
    //     if (triggerOnServerOnly == true && GameManager.Instance.mIsMulti && !GameNetManager.Instance.IsServerSide())
    //         return;
    //     else if (triggerOnServerOnly == false && GameManager.Instance.mIsMulti && GameNetManager.Instance.IsServerSide())
    //         return;
    //     Collider otherCollider = other.GetComponent<Collider>();
    //     if (OnTriggerColliderEnter != null)
    //         this.OnTriggerColliderEnter.Invoke(this.gameObject, otherCollider);
    // }
}
