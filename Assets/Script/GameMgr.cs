using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public GameObject[] Models;
    bool isZoomIn;
    bool isZoomOut;

    bool isMoveLeft;
    bool isMoveRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Zoom
        for (int i = 0; i < Models.Length; i++)
        {
            if (isZoomIn)
            {
                Models[i].transform.localScale += new Vector3(0.0001f, 0.0001f, 0.0001f);
            }
            else if (isZoomOut)
            {
                Models[i].transform.localScale -= new Vector3(0.0001f, 0.0001f, 0.0001f);
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
