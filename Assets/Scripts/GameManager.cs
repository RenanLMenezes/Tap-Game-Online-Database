using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
        
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
