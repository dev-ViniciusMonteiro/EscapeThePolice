using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
    {
        bool _gameOver = false;
        [SerializeField] private float restartDelay = 2f;
        public void EndGame()
        {
            
            if (!_gameOver)
            {
                _gameOver = true;
                Debug.Log("GAME OVER!");
                //restart
                Invoke("Restart", restartDelay);
            }
        }

        void Restart()
        {
            SceneManager.LoadScene("level 1");
        }
    }
