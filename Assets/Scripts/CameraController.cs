using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _endFinishCameraPoint;


    public void MoveCameraToFinishPoint()
    {
        transform.DOMove(_endFinishCameraPoint.position, 1f);
    }
}
