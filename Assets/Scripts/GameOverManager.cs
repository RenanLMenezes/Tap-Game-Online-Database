using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        score.text = $"Your Score: {GameManager.score}";
        highScore.text = $"Your Score: {GameManager.nicknameHighScore} - {GameManager.highScore}";
        GameManager.SetScore();
        Invoke("GoMenu", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
