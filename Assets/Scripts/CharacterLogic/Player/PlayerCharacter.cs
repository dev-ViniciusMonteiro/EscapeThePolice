using System;
using System.Collections;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    public event Action<float> OnHealthPictureChanged = delegate { };
    
    private float _currentHealth;
    public bool IsAlive { get; set; }

    void Start()
    {
        IsAlive = true;
        _currentHealth = _maxHealth;
    }

    public void Hurt(int damage)
    {
        _currentHealth -= damage;
        
        float currentHealthPicture = (float) _currentHealth / (float) _maxHealth;
        OnHealthPictureChanged(currentHealthPicture);

        
        if (_currentHealth.Equals(0.0f))
        {
            IsAlive = false;
            StartCoroutine(Die());
            return;
        }
        
        Debug.Log($"Health is damaged at {damage}. Now {_currentHealth}");
    }

    private IEnumerator Die()
    {
        Debug.Log("You`re dead.");
        yield return new WaitForSeconds(2.0f);
    }
}