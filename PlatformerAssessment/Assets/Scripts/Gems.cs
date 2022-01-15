using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour
{
    public Text gameOverScore;
    public Text gameOverGems;
    public GameObject levelManager;
    public Text score;
    public int scoreValue;
    float wave = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(
            transform.position.x, 
            transform.position.y + Mathf.Sin(wave * 0.25f) * 0.25f * Time.deltaTime,
            transform.position.z
        );
        transform.position = position;
        wave++;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            levelManager.GetComponent<LevelManager>().gems--;
            other.GetComponent<PlayerController>().score += 10;
            score.text = "Score: " + other.GetComponent<PlayerController>().score;
            gameOverScore.text = "Score: " + other.GetComponent<PlayerController>().score;
            gameOverGems.text = "Gems: " + other.GetComponent<PlayerController>().score / 10;
        }
    }
}
