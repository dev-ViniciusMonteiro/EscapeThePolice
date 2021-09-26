using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    
    private GameOverController _controller;
    private GameObject _player;
    private Vector3 _PsicaoInicial;

    void Start()
    {
        _controller = GameObject.Find("SceneController").GetComponent<GameOverController>();
        _PsicaoInicial = GameObject.FindWithTag("Respawn").transform.position;
         _player = Instantiate(_playerPrefab, _PsicaoInicial, transform.rotation) as GameObject;
        _player.transform.parent = GameObject.Find("Player").transform;

    }
}