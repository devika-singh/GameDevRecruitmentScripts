using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{
    public GameObject tubeU;
    public GameObject scoreText;
    public GameObject scoreScore;
    public GameObject Camera;
    private Camera mainCamera;
    private float score;
    // Start is called before the first frame update\
    private float initialPlayerPos;
    void Start()
    {
        initialPlayerPos = transform.position.x;
        mainCamera = Camera.GetComponent<Camera>();

        score = 0;
        tubeU = Instantiate(tubeU) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (tubeU.GetComponentInChildren<Transform>().position.x < transform.position.x)
        {
            score += 0.01f;
            scoreText.GetComponent<Text>().text = ((int)score).ToString(); 
        }
    }
}
