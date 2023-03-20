using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cannvu : MonoBehaviour
{
    //private Tapping taps;
    public int whom;
    public string iCry;

    public bool stupid;
    public string iField;

    public TextMeshProUGUI typewriter;
    // Start is called before the first frame update
    void Start()
    {
        stupid = false;
        typewriter = FindObjectOfType<TMPro.TextMeshProUGUI>();

        //taps = FindObjectOfType<Tapping>();

        whom = Random.Range(1, 5);

        if (whom == 1)
        {
            iCry = "Dear Mother, ";
        }
        else if (whom == 2)
        {
            iCry = "Dear Father, ";
        }
        else if (whom == 3)
        {
            iCry = "Dear Lover, ";
        }
        else if (whom == 4)
        {
            iCry = "Dear Sister, ";
        }
        else if (whom == 5)
        {
            iCry = "Dear Brother, ";
        }

        typewriter.text = iCry;
    }

    // Update is called once per frame
    void Update()
    {
        if(stupid)
        {
            iField += (" ");
            stupid = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        
    }

    public void spaceBar()
    {
        stupid = true;
        Debug.Log("I hit the Space");
    }

    public void startingGame()
    {

    }
}
