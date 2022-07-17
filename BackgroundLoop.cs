using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] levels;
    private Camera mainCamera;
    public float choke;
    public float tube1Offset;
    public float tube2Offset;
    private Vector2 screenBounds;
    private float prevTubeYUpper;
    static private int score;
    private Vector3 TubePosition;
    private bool IsOnRight;
    private void Start()
    {
        score = 0;
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, mainCamera.transform.position.z));
       
        Invoke("loadChildFor", 3f);
    }

    private void loadChildFor()
    {
        int i = 0;
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj, i++);
        }
    }

    void loadChildObjects(GameObject obj, int objNumber)
    {
            float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x + choke;
            int childNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
            float set;
            switch (objNumber)
            {
                case 1:
                case 2:
                    set = tube1Offset;
                    break;
                //case 3:
                //case 4:
                  //  set = tube2Offset;
                    //break;
                default:
                    set = 0;
                    break;
            }
            GameObject clone = Instantiate(obj) as GameObject;
            for (int i = 0; i <= childNeeded; i++)
            {
                GameObject child = Instantiate(clone) as GameObject;
                child.transform.SetParent(obj.transform);
                child.transform.position = new Vector3((float)((objectWidth * i) - set), obj.transform.position.y, obj.transform.position.z);
                child.name = obj.name + i;

            }
            Destroy(clone);
            Destroy(obj.GetComponent<SpriteRenderer>());
        
    }
    void repositionChildObjects(GameObject obj,int objNumber)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x + choke;
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();

                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
                randomizeY(obj, objNumber);
            }else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth){
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
                randomizeY(obj, objNumber);
            }
        }
      

    }

    private void randomizeY(GameObject obj, int objNumber)
    {
        float yVal;
        switch (objNumber)
        {
            case 1://Upper 1
                yVal = Random.Range(7.9826f,2.02f);
                prevTubeYUpper = yVal;
                setY(obj, yVal);
                break;
            case 2://Lower 1
                yVal = prevTubeYUpper - 10;
                setY(obj, yVal);
                break;
           // case 3://Upper 2
              //  yVal = Random.Range(7.9826f, 2.02f);
                //prevTubeYUpper = yVal;
                //setY(obj, yVal);
                //break;
            //case 4://Lower 2
                //yVal = prevTubeYUpper - 10;
                //setY(obj, yVal);
                //break;
            default:
                break;
        }
    }
    private void setY(GameObject obj, float yTransform)
    {
        float initialY = obj.transform.position.y;
        obj.transform.position += new Vector3(0, -initialY + yTransform, 0);
        TubePosition = obj.transform.position;
        if(TubePosition.x > Player.transform.position.x)
        {
            IsOnRight = true;
        }
        else
        {
            IsOnRight = false;
        }
    }
    private void LateUpdate()
    {
            int i = 0;
            foreach (GameObject obj in levels)
            {
                repositionChildObjects(obj, i++);
            }
    }
    private void Update()
    {
        if(IsOnRight && TubePosition.x <= Player.transform.position.x)
        {
            score++;
        }
        Debug.Log(IsOnRight);
    }

    public string ScroreFromBackgroundLoop()
    {
        return score.ToString();
    }
}
