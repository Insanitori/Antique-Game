using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Tapping : MonoBehaviour
{
    public Cannvu canvas;
        // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Cannvu>();
    }

    // Update is called once per frame
    void Update()
    {

        //Input.touchCount is the amount of touches that are currently on screen
        //Check to see if there are any touches happening
        if (Input.touchCount > 0)
        {
            //let's check if the touch is a new touch
            //there are a few different phases that touch moves through
            //check them here: https://docs.unity3d.com/ScriptReference/TouchPhase.html

            //Input.touches[] is an array that stores all touches, the first touch is marked at 0 
            //Has the first touch just started?
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                //Raycast- think of a laser pointer going towards a specific direction 
                //We create a Ray from the near plane of the camera using ScreenPointToRay 
                //make a variable Ray, set it to the position of our first touch
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                //We need a RaycastHit- this stores all the infomration about what the ray hits
                RaycastHit hit;

                //now we need to "cast" the ray- turn on the laser pointer & have it return what it hits
                if (Physics.Raycast(ray, out hit)) //out is a keyword that means after this runs there will be a value coming OUT of the hit
                {
                    //If I hit something with a collider
                    if (hit.collider != null)
                    {
                        if(hit.collider.gameObject.tag != "Finish" && hit.collider.gameObject.tag != "Untagged")
                        {
                            canvas.iField += (hit.collider.gameObject.tag);

                            hit.collider.gameObject.GetComponent<Alphabet>().touched = true;
                            
                        }
                        else
                        {
                            canvas.typewriter.text = canvas.iCry + canvas.iField;
                        }
                    }
                }

            }
        }
    }
}
