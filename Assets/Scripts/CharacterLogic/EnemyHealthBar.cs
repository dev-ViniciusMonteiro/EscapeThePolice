using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    private CameraController _cameraController;

    void Start(){
        _cameraController = GameObject.Find("ViewManager").GetComponent<CameraController>();
        GetComponentInParent<ReactiveTarget>().OnHealthPictureChanged += HandleHealthChange;
    }

    private void LateUpdate(){
        transform.LookAt(_cameraController.currentCamera.transform);
        transform.Rotate(0, 180, 0);
    }

    private void HandleHealthChange(float pictureData){
        _healthBarImage.fillAmount = Mathf.Lerp(_healthBarImage.fillAmount, pictureData, 1);
    }
    
}