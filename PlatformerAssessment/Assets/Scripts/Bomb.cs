using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            levelManager.GetComponent<LevelManager>().GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
