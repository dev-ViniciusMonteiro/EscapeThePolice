using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private CameraController _cameraController;

    [SerializeField] private Image _healthBarImage;
    // [SerializeField] private float _lerpSpeed;

    void Awake()
    {
        _cameraController = GameObject.Find("ViewManager").GetComponent<CameraController>();
        GetComponentInParent<ReactiveTarget>().OnHealthPictureChanged += HandleHealthChange;
    }

    private void LateUpdate()
    {
        transform.LookAt(_cameraController.currentCamera.transform);
        transform.Rotate(0, 180, 0);
    }

    private void HandleHealthChange(float pictureData)
    {
        _healthBarImage.fillAmount = Mathf.Lerp(_healthBarImage.fillAmount, pictureData, 1);
    }
}