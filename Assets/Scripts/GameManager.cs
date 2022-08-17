using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0;
    public static int highScore = 0;
    public static float time;
    public static string nickname = "";
    public static string nicknameHighScore = "";


    //propriedades/dados do objeto
    [SerializeField]
    private List<GameObject> targets;
    private int maxSpawn = 0;
    private float timeSpawn = 0;

    //propriedadades da HUD
    [SerializeField]
    private TMP_Text txtScore;
    [SerializeField]
    private TMP_Text txtTimer;

    // Start is called before the first frame update
    void Start()
    {
        time = 50f;
        maxSpawn = 3;
        timeSpawn = 1.5f;
        StartGame();
        Debug.Log(score);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        UpdateHUD();
        if (time <= 0)
        {
            Invoke("GoGameOver", 2);
        }
    }

    private void UpdateHUD()
    {
        if(txtScore != null)
        {
            txtScore.text = $"Score: {score}";
        }

        if (txtTimer != null)
        {
            txtTimer.text = time > 0 ? $"Time: {time.ToString("F0")}" : "Time: 0";
        }
    }

    private void StartGame()
    {
        StartCoroutine(SpawnTargets());
        StartCoroutine(ChangeDificult());
        score = 0;
    }

    private IEnumerator ChangeDificult() {
        while (timeSpawn > 1)
        {
            yield return new WaitForSeconds(10);
            timeSpawn -= 0.1f;
            maxSpawn ++;
        }
    }

    private IEnumerator SpawnTargets()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(timeSpawn);
            for (int i = 0; i < maxSpawn; i++)
            {
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }
    }

    private void GoGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
