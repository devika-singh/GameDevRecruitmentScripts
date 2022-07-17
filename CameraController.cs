using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public GameObject background;
    private GameObject cloneBg;
    private Camera cam;
    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        cloneBg = Instantiate(background) as GameObject;
        cam = gameObject.GetComponent<Camera>();
        //Debug.Log(target.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cam.name);
        //
        float yBound = cloneBg.GetComponent<SpriteRenderer>().bounds.size.y /2 - cam.GetComponent<Camera>().orthographicSize;
        float targetY = target.transform.position.y;
        //Debug.Log(yBound);
        if ((target.transform.position.y < yBound ) && (target.transform.position.y > -yBound))
        {
            transform.position = target.transform.position + new Vector3(1, 0, -8);
        }
        else if(target.transform.position.y < -yBound)
        {
            float xVal = target.transform.position.x + 1;
            float zVal = target.transform.position.z - 8;
            transform.position =  new Vector3(xVal, -yBound, zVal);
            Invoke("RestartScene", 2);

        }
        else
        {
            float xVal = target.transform.position.x + 1;
            float zVal = target.transform.position.z - 8;
            transform.position = new Vector3(xVal, yBound, zVal);
            Invoke("RestartScene", 2);

        }
    }
    public void RestartScene()
    {
        scoreText.GetComponent<Text>().text = "0";
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
