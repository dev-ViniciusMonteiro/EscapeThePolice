using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action<float> OnHealthPictureChanged = delegate { };
    public bool IsAlive { get; set; }

    private float _currentHealth;
    private float _equals = 0.0f;
    private float _time = 2f;

    void Start(){
        IsAlive = true;
        _currentHealth = _maxHealth;
    }

    public void Hurt(int damage){
        _currentHealth -= damage;
        
        float currentHealthPicture = (float) _currentHealth / (float) _maxHealth;
        OnHealthPictureChanged(currentHealthPicture);
 
        if (_currentHealth.Equals(_equals)){
            IsAlive = false;
            StartCoroutine(Die());
            return;
        } 
    }

    private IEnumerator Die(){
        Debug.Log("PERDEU!!!");
        yield return new WaitForSeconds(_time);
        SceneManager.LoadScene("iniciofim");
    }
}