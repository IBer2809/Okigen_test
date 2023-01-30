using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyour : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Material _conveyourBeltMat;
    [SerializeField] private float _conveyourBeltSpeed;

    private void Start()
    {
        _conveyourBeltMat.mainTextureOffset = Vector2.zero;
    }
    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.Play)
            _conveyourBeltMat.mainTextureOffset += Vector2.right * _conveyourBeltSpeed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision col)
    {
        col.transform.position = Vector3.MoveTowards(col.transform.position, _endPoint.position, _moveSpeed * Time.deltaTime);
    }
}
