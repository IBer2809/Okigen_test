using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private Transform _rightArmTarget;
    [SerializeField] private Basket _basket;
    private PickUp _currentFruit;
    

    public void PickUpFruit(PickUp fruit)
    {
        _currentFruit = fruit;
        _characterAnimator.SetTrigger("PickUp");
    }
    public void SetParentForFruit()
    {
        _currentFruit.transform.SetParent(_rightArmTarget, true);
        _currentFruit.transform.localPosition = Vector3.zero;
    }

    public void UnsetParentForFruit()
    {
        _currentFruit.UnfreezeFruitRigidbody();
        _currentFruit.transform.SetParent(null, true);
        StartCoroutine(_basket.DisableUpperBasketCollider(_currentFruit));
    }

    public void ActivePlayerDance() => _characterAnimator.SetTrigger("Dancing");

    public void SetDefaultAnim() => _characterAnimator.SetTrigger("Playing");
}
