using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int _numberOfKilled;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int maxEnemiesAtLevel;
    private GameOverController _controller;
    private GameObject _enemy;
    private Vector3 _posicaoInicial;
    private int _quantidade;

    void Start(){
        _posicaoInicial = GameObject.Find("EnemySpawner").transform.position;
        _controller = GameObject.Find("SceneController").GetComponent<GameOverController>();
    }

  
    void FixedUpdate(){
        if (_quantidade < maxEnemiesAtLevel){
              _enemy = Instantiate(_enemyPrefab, _posicaoInicial, transform.rotation) as GameObject;
            _enemy.transform.Rotate(0, Random.Range(0, 360), 0);
            _quantidade++;
        }

        if (_numberOfKilled == maxEnemiesAtLevel){
            _controller.EndGame();
        }
    } 
}