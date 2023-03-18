using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    [Range(-360,360)]
    public float xMove = 0;
    public float xSpeed = 1;
    [Range(-90,90)]
    public float yMove = 0;
    public float ySpeed = 1;
    public float lerpSpeed = 0.01f;
    public GameObject xRotation;
    public GameObject yRotation;
    public float squareCleanDistance = 40000;

    Vector2 deltaPosition = new Vector2();
    string tool = "drag";

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0) {

            switch (tool) {

                case "drag":

                    switch (Input.GetTouch(0).phase) {

                        case TouchPhase.Began:



                        break;
                        case TouchPhase.Moved:

                            move(Input.GetTouch(0).deltaPosition);

                        break;
                        case TouchPhase.Ended:



                        break;

                    }

                break;
                case "clean":

                    if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).deltaPosition != Vector2.zero) {

                        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dirt")) {

                            if (g.GetComponent<DirtController>().cleanable && (g.GetComponent<DirtController>().screenPosition - (Vector2)Input.mousePosition).SqrMagnitude() <= squareCleanDistance) {

                                Destroy(g);

                            }

                        }

                    }

                break;

            }


        }
        float xDifference = Mathf.Abs(xRotation.transform.localEulerAngles.y - xMove);
        float yDifference = Mathf.Abs(yRotation.transform.localEulerAngles.x - yMove);
        yDifference %= 360;
        xDifference %= 360;
        bool updateCleanable = false;
        if (xDifference < 0.01f) {}
        else if (xDifference < 1) {

            xRotation.transform.localEulerAngles = new Vector3(0, xMove, 0);
            updateCleanable = true;
            Debug.Log("xDifference = " + xDifference);

        }
        else {

            xRotation.transform.localEulerAngles = new Vector3(0 ,Mathf.LerpAngle(xRotation.transform.localEulerAngles.y, xMove, lerpSpeed) ,0);
            updateCleanable = true;
            Debug.Log("xDifference = " + xDifference);

        }
        if (yDifference < 0.01f) {}
        else if (yDifference < 1) {

            yRotation.transform.localEulerAngles = new Vector3(yMove, 0, 0);
            updateCleanable = true;
            Debug.Log("yDifference = " + yDifference);

        }
        else {

            yRotation.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(yRotation.transform.localEulerAngles.x, yMove, lerpSpeed), 0, 0);
            updateCleanable = true;
            Debug.Log("yDifference = " + yDifference);

        }
        if (updateCleanable) {

            DirtController.updateAllCleanable(); 

        }


    }

    public void setToDrag() {

        Debug.Log("setting to drag");
        tool = "drag";

    }

    public void setToSpray() {

        tool = "spray";

    }

    public void setToClean() {

        Debug.Log("setting to clean");
        tool = "clean";

    }

    void move(Vector2 moveBy_) {

        xMove -= moveBy_.x * xSpeed;
        xMove %= 360;
        if (xMove < 0) {

            xMove += 360;

        }
        yMove += moveBy_.y * ySpeed;
        if (yMove > 90) {

            yMove = 90;

        }
        else if (yMove < -90) {

            yMove = -90;

        }     

    }

}
