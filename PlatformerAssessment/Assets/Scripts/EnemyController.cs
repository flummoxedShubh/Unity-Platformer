using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject GameOver;
    public GameObject bomb;
    public Transform bombDropper;
    float wave = 0f;
    float timeBetweenSpawns = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBomb", timeBetweenSpawns, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(
            transform.position.x + Mathf.Sin(wave * 0.05f) * Time.deltaTime * 10f, 
            transform.position.y,
            transform.position.z
        );
        transform.position = position;
        wave++;
    }

    void SpawnBomb()
    {
        Instantiate(bomb, bombDropper.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
