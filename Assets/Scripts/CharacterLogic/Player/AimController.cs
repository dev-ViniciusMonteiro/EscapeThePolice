using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private float _reloadDelay = 3f;
    [SerializeField] private GameObject _bulletPrefab;

    private GameObject _bullet;
    private bool _isReloading;
    private int _myBullet = 0;

    void Start(){
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isReloading = false;
    }

    void OnGUI(){
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update(){
        RayCast();
    }

    //nao tocar 
    void RayCast(){
        if (Input.GetMouseButtonDown(0) && !_isReloading){
            var point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            var ray = _camera.ScreenPointToRay(point);

            if (Physics.Raycast(ray)){
                _bullet = Instantiate(_bulletPrefab) as GameObject;
                _bullet.transform.position = transform.TransformPoint(Vector3.forward * 0.1f);
                _bullet.transform.rotation = transform.rotation;
                _myBullet+=1;
                if(_myBullet>9){
                    StartCoroutine(Reload());
                }
            }
        }
    }

    private IEnumerator Reload(){
        _isReloading = true;
        _myBullet = 0;
        Debug.Log("Reloading + 10 bullets");
        yield return new WaitForSeconds(_reloadDelay);
        _isReloading = false;
    }
}