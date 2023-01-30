using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations.Rigging;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform _armPoint;
    [SerializeField] private Transform _headAim;
    [SerializeField] private Vector3 _armOffset;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private Transform _basketPoint;
    private Quaternion _startArmPointRotation;
    private Vector3 _startArmPointPosition;
    private Vector3 _startAimPosition;
    private bool _isArmMoving = false;
    private PickUp _pickUpFruit;
    [SerializeField] private TwoBoneIKConstraint _leftArmIK;
    [SerializeField] private GameObject _basket;

    private void Start()
    {
        _startArmPointPosition = _armPoint.position;
        _startArmPointRotation = _armPoint.rotation;
        _startAimPosition = _headAim.position;
    }



    public IEnumerator MoveArmToFruit(PickUp pickUp)
    {
        _pickUpFruit = pickUp;
        _isArmMoving = true;
        pickUp.FreezeFruitRigidbody();
        _animationController.PickUpFruit(pickUp);
        yield return new WaitForSeconds(1f);
        _isArmMoving = false;
        StartCoroutine(MoveArmToBasket());

    }

    private IEnumerator MoveArmToBasket()
    {
        _armPoint.DOMove(_basketPoint.position, 1f);
        _armPoint.DORotateQuaternion(_basketPoint.rotation, 1f);
        yield return new WaitForSeconds(1f);
        RestartArmPosRot();

    }

    private void RestartArmPosRot()
    {
        _armPoint.DOMove(_startArmPointPosition, 1f);
        _armPoint.DORotateQuaternion(_startArmPointRotation, 1f);
        _headAim.DOMove(_startAimPosition, 1f);
    }

    public void CharacterOnFinish()
    {
        _basket.SetActive(false);
        for (int i = 0; i < _basket.transform.childCount; i++)
        {
            _basket.transform.GetChild(i).gameObject.SetActive(false);
        }
        _leftArmIK.weight = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Debug.Log(_armPoint.transform.position);
        if (_pickUpFruit != null)
        {
            if (_isArmMoving)
            {
                _headAim.DOMove(_pickUpFruit.transform.position, 0.25f);
                _armPoint.DOMove(_pickUpFruit.transform.position + _armOffset, 1f);
            }
        }
    }
}
