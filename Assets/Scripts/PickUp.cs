using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody _fruitRigidbody;
    private Collider _fruitCollider;
   

    private void Start()
    {
        _fruitCollider = GetComponent<Collider>();
        _fruitRigidbody = GetComponent<Rigidbody>();
        _fruitRigidbody.constraints = RigidbodyConstraints.None;
    }


    public void UnfreezeFruitRigidbody()
    {
        _fruitRigidbody.constraints = RigidbodyConstraints.None;
    }


    public void FreezeFruitRigidbody()
    {
        _fruitRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public Rigidbody GetFruitRigidbody()
    {
        return _fruitRigidbody;
    }

    public Collider GetFruitCollider()
    {
        return _fruitCollider;
    }
}
