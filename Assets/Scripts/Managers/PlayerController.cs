using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    
    private GameOverController _controller;
    private GameObject _player;
    private Vector3 _initialPosition;

    void Start()
    {
        _controller = GameObject.Find("SceneController").GetComponent<GameOverController>();
        _initialPosition = GameObject.FindWithTag("Respawn").transform.position;
        
        CreatePlayer();
    }


    void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _initialPosition, transform.rotation) as GameObject;
        _player.transform.parent = GameObject.Find("Player").transform;
    }
}