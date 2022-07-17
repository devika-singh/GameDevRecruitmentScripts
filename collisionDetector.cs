using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collisionDetector : MonoBehaviour
{
    public Animator deathAnimation;
    public AudioSource crashSound;
    public GameObject scoreText;
    public GameObject HighScore;
    static int highScore;
    private void Start()
    {
        HighScore.GetComponent<Text>().text = highScore.ToString();
        crashSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit detected");
        crashSound.Play();
        deathAnimation.SetBool("IsCollision", true);
        Invoke("RestartScene",2);
        //GameObject e = Instantiate(deathAnimation) as GameObject;
        //e.transform.position = transform.position;
    }
    public void RestartScene()
    {
        //Debug.Log(HighScore.GetComponent<Text>().text + int.Parse(scoreText.GetComponent<Text>().text));
        int currentScore;
        int.TryParse(HighScore.GetComponent<Text>().text, out highScore);
        int.TryParse(scoreText.GetComponent<Text>().text, out currentScore);
        Debug.Log("why");
        Debug.Log(highScore);
        if (highScore < currentScore)
        {
            highScore = currentScore;
        }
        scoreText.GetComponent<Text>().text = "0";
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
