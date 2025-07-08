using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSlideController : MonoBehaviour
{
    public GameObject[] panelOut;
    //Panels needed to be out of frame
    public GameObject[] panelIn;
    //Panels needed in frame
    private Button btn;
    //this button

    //Setting the variables needed in this script

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        //gets the button component
        btn.onClick.AddListener(SlideStart);
        //sets the SlideStart method to start on button click
    }

    void SlideStart()
    //Declares the method
    {
        foreach (GameObject panel in panelOut)
        //Goes through all the panels needed to slide out of the way
        {
            PanelSlide slideOutPanel = panel.GetComponent<PanelSlide>();
            //Gets the script for the panel
            StartCoroutine(slideOutPanel.SlideOutCo());
            //calls the panels slide out coroutine
        }
        foreach (GameObject panel in panelIn)
        //goes through all the panels needed to move into frame
        {
            PanelSlide slideInPanel = panel.GetComponent<PanelSlide>();
            //Gets the script for the panel
            StartCoroutine(slideInPanel.SlideInCo());
            //calls the panels slide in coroutine
        }
    }

}