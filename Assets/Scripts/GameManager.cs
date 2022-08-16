using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0;

    //propriedades/dados do objeto
    [SerializeField]
    private List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        this.StartCoroutine(SpawnTargets());
        GameManager.score = 0;
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(1f);
        }
    }
}
