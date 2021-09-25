using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    // [SerializeField] private float _lerpSpeed;

    void Start()
    {
        var player = GameObject.Find("Player");
        player.GetComponentInChildren<PlayerCharacter>().OnHealthPictureChanged += HandleHealthChange;
    }

    private void HandleHealthChange(float pictureData)
    {
        _healthBarImage.fillAmount = Mathf.Lerp(_healthBarImage.fillAmount, pictureData, 1);
    }
}