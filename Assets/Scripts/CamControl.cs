using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControl : MonoBehaviour
{
    private GameObject normalViewCam;
    private Button switchBtn;
    private Button topBtn;
    private Button normBtn;
    private bool normCam = true;

    //Setting the variables needed in this script

    void Start()
    {
        normalViewCam = GameObject.FindGameObjectWithTag("NormCam");
        //Finds the Normal view virtual camera
        switchBtn = GameObject.Find("SwitchCamBtn").GetComponent<Button>();
        topBtn = GameObject.Find("TopCamBtn").GetComponent<Button>();
        normBtn = GameObject.Find("NormalViewBtn").GetComponent<Button>();
        //Gets all of the buttons that will need to be pressed
        switchBtn.onClick.AddListener(SwitchCam);
        topBtn.onClick.AddListener(TopCamSwitch);
        normBtn.onClick.AddListener(NormCamSwitch);
        //Sets all of the buttons to activate their respective methods on click
    }

    void TopCamSwitch()
    //Declares a method
    {
        normalViewCam.SetActive(false);
        //Deactivates the normal view virtual camera
        normCam = false;
        //keeps track of wether or not the normal view is active
    }

    void NormCamSwitch()
    //Declares a method
    {
        normalViewCam.SetActive(true);
        //Activates the normal view virtual camera
        normCam = true;
        //keeps track of wether or not the normal view is active
    }

    void SwitchCam()
    //Declares a method
    {
        if (normCam)
        //Checks if the normal view is active
        {
            TopCamSwitch();
            //Calls the method to switch to the top camera
        }
        else
        {
            NormCamSwitch();
            //Calls the method to switch to the normal camera
        }
    }
}
