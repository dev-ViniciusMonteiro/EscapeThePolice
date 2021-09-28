using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
    {
        bool _gameOver = false;
        [SerializeField] private float restartDelay = 2.5f;
        public void EndGame()
        {
            
            if (!_gameOver)
            {
                _gameOver = true;
                Debug.Log("Fim!");
                Invoke("Restart", restartDelay);//reinicia com delay 2.5
            }
        }

        void Restart()
        {
            SceneManager.LoadScene("iniciofim");
        }
    }
