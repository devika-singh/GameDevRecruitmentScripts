using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public GameObject background;
    public Animator deathAnimation;
    private GameObject cloneBg;
    // Start is called before the first frame update
    void Start()
    {
        cloneBg = Instantiate(background) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        float yBound = cloneBg.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //Debug.Log(yBound);
        if ((transform.position.y >= yBound) || (transform.position.y <= -yBound))
        {
            Debug.Log("You Lost OutOfBounds!");
            deathAnimation.SetBool("IsCollision", true);
        }
    }
    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
