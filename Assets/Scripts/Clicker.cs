using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _clickDelay;
    [SerializeField] private float _timeAfterClick;

    private void Start()
    {
        _timeAfterClick = 0;
    }
    private void Update()
    {
        _timeAfterClick += Time.deltaTime;
        if (GameManager.Instance.CurrentState == GameManager.GameState.Play)
        {
            RaycastHit hit;
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
                if (hit.collider.TryGetComponent(out PickUp pickUp))
                {
                    if(Input.GetMouseButtonDown(0) && _timeAfterClick > _clickDelay)
                    {
                        _timeAfterClick = 0;
                        StartCoroutine(_characterController.MoveArmToFruit(pickUp));
                    }
                    
                }
        }

    }
}
