using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BuildManager : MonoBehaviour
{
    public GameObject turretToBuild;
    private GameObject textPanel;
    public TextMeshProUGUI infoBox;
    public Material neutral;
    public Material active;

    //Setting the variables needed in this script

    void Start()
    {
        Node[] nodes = FindObjectsOfType(typeof(Node)) as Node[];
        // Collecting an array of the nodes at runtime
        textPanel = GameObject.FindWithTag("TextBox");
        // Finds the UI panel that contains relevant information
        int i = 0;
        GameObject[] btnContainer = GameObject.FindGameObjectsWithTag("TurretBtn");
        // An array that will reference all buttons for turrets. This is so that adding more turrets
        // will be easier
        TurretSelect[] btnObject = new TurretSelect[btnContainer.Length];
        // Sets an array to the same length as the one above so that they can have information
        // about the same turret with the same index number
        foreach (GameObject towerBtn in btnContainer)
        {
            int tempI = i;
            // temporary variable as 'i' will change and so will the reference
            btnObject[tempI] = towerBtn.GetComponent<TurretSelect>();
            //Sets the btnObject array with the same index to a reference to the script
            //with the information attached
            towerBtn.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                SelectTurret(btnObject[tempI], nodes);
            });
            //Sets the referenced button to attach to the select turret method
            //with the relevant information included
            i++;
        }
    }

    void SelectTurret(TurretSelect turretSet, Node[] nodes)
    {
        if (turretSet.turret.CompareTag("Tower"))
        //Checks if the selected turret is a tower type
        {
            foreach (Node placement in nodes)
            //Goes through each node in the scene
            {
                if (placement.transform.CompareTag("TowerBaseNode"))
                //Checks if the current node checked is for the towers
                {
                    placement.GetComponent<MeshRenderer>().material = active;
                    //Sets the material to an active green material with bloom
                }
            }
        }
        else
        //Checks if the selected turret is not a tower type
        {
            foreach (Node placement in nodes)
            //Goes through each node in the scene
            {
                if (placement.transform.CompareTag("TurretNode"))
                //Checks if the current node checked is for the Base
                {
                    placement.GetComponent<MeshRenderer>().material = active;
                    //Sets the material to an active green material with bloom
                }
            }
        }
        turretToBuild = turretSet.turret;
        //Sets a variable to the prefab reference
        if (turretSet.infoText != "")
        //Checks if there is any information Text for the selected object
        {
            infoBox.text = turretSet.GetComponent<TurretSelect>().infoText;
            //Sets the text to the correct information
            StartCoroutine(textPanel.GetComponent<PanelSlide>().SlideInCo());
            //Starts a coroutine to slide the textbox in
        }
    }

    public void DeselectTurret()
    {
        Node[] nodes = FindObjectsOfType<Node>();
        // Finds all nodes in the scene
        foreach (Node placement in nodes)
        //Goes through all the nodes
        {
            placement.GetComponent<MeshRenderer>().material = neutral;
            //Sets the material to a neutral material
        }
        turretToBuild = null;
        //Clears the current turret building
        StartCoroutine(textPanel.GetComponent<PanelSlide>().SlideOutCo());
        //Slides the infobox out of the way
    }
}
