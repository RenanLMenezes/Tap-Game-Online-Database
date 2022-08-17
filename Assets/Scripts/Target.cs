using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 14f;
    private float maxSpeed = 18f;
    private float maxTorque = 5f;
    private float xRange = 5f;
    private float ySpawnPos= -6f;
    private Rigidbody rb;
    private AudioSource sfx;

    [SerializeField]
    private int _score;
    [SerializeField]
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();

        transform.position = RandomSpawnPos();

        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque ()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        sfx.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        if (this.tag == "GoodTarget" && GameManager.time > 0)
        {
            GameManager.score += _score;
            GameManager.time += _time;
        }

        if (this.tag == "BadTarget" && GameManager.time > 0)
        {
            GameManager.time -= _time;
        }
        Debug.Log(GameManager.score);
        Destroy(gameObject, 1f);
    }

}
