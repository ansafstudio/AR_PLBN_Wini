using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public GameObject[] Models;
    bool isZoomIn;
    bool isZoomOut;

    bool isMoveLeft;
    bool isMoveRight;

    bool isZoomText;
    float indexZoom = 0;

    // Use this for initialization
    void Start () {
        indexZoom = 0.0001f;

        StartCoroutine(ShowMap());
    }

    IEnumerator ShowMap()
    {
        for (int i = 0; i < Models.Length; i++)
        {
            if (i == 4)
            {
                Models[i].SetActive(true);
            }
            else
            {
                Models[i].SetActive(false);
            }
        }
        isZoomText = true;

        yield return new WaitForSeconds(5);


        for (int i = 0; i < Models.Length; i++)
        {
            if (i == 4)
            {
                Models[i].SetActive(false);
            }
            else
            {
                Models[i].SetActive(true);
            }
        }
        isZoomText = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Zoom
        for (int i = 0; i < Models.Length; i++)
        {
            if (i == 1 || i == 3)
            {
                indexZoom = 0.01f;
            }
            else if (i == 4 && isZoomText)
            {
                //indexZoom = 0.0005f;
                Models[i].transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            }
            else
            {
                indexZoom = 0.0001f;
            }

            if (isZoomIn)
            {
                Models[i].transform.localScale += new Vector3(indexZoom, indexZoom, indexZoom);
            }
            else if (isZoomOut)
            {
                Models[i].transform.localScale -= new Vector3(indexZoom, indexZoom, indexZoom);
            }

            if (isMoveLeft)
            {
                Models[i].transform.Translate(Vector3.right * Time.deltaTime * 5);
            }
            else if (isMoveRight)
            {
                Models[i].transform.Translate(Vector3.left * Time.deltaTime * 5);
            }
        }
    }

    //Zoom
    public void ZoomINPressed()
    {
        isZoomIn = true;
    }
    public void ZoomINReleased()
    {
        isZoomIn = false;
    }

    public void ZoomOUTPressed()
    {
        isZoomOut = true;
    }
    public void ZoomOUTReleased()
    {
        isZoomOut = false;
    }

    //Move
    public void MoveLeftPressed()
    {
        isMoveLeft = true;
    }
    public void MoveLeftReleased()
    {
        isMoveLeft = false;
    }

    public void MoveRightPressed()
    {
        isMoveRight = true;
    }
    public void MoveRightReleased()
    {
        isMoveRight = false;
    }
}
