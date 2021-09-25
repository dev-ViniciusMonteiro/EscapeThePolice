using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int maxEnemiesAtLevel;

    private GameOverController _controller;
    private GameObject _enemy;
    private Vector3 _initialPosition;
    public int _numberOfKilled;
    private int _currentQuantity;

    void Start()
    {
        _initialPosition = GameObject.Find("EnemySpawner").transform.position;
        _controller = GameObject.Find("SceneController").GetComponent<GameOverController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_currentQuantity < maxEnemiesAtLevel)
        {
            CreateEnemy();
        }
        if (_numberOfKilled == maxEnemiesAtLevel)
        {
            _controller.EndGame();
        }
    }

    void CreateEnemy()
    {
        _enemy = Instantiate(_enemyPrefab, _initialPosition, transform.rotation) as GameObject;
        _enemy.transform.Rotate(0, Random.Range(0, 360), 0);
       // _enemy.transform.parent = GameObject.Find("Enemies").transform;
        _currentQuantity++;
    }
    
   
}