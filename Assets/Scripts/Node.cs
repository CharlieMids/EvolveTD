using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    private Renderer rend;
    private BuildManager buildingType;
    private float offset;
    private GameObject rangeDisplay;

    //Setting the variables needed in this script


    private void Start()
    {
        rend = GetComponent<Renderer>();
        //Gets the renderer for the object
        buildingType = GameObject.FindGameObjectWithTag("UI").GetComponent<BuildManager>();
        //Gets the reference for the build manager script
    }

    private void OnMouseDown()
    //When this collider is clicked
    {
        if (buildingType.tag == null)
        //if the player has no tower selected
        {
            Debug.Log("Select a tower!");
            //Puts text in the log - placeholder until there is a popup implemented
        }
        if (gameObject.tag == "TurretNode" && buildingType.turretToBuild.tag == "Turret")
        //If the player clicks on a turret node with a turret selected
        {
            Buildhere();
            //Calls the function to place the tower on this node
        }
        else if (gameObject.tag == "BaseNode" && buildingType.turretToBuild.tag == "BaseBuilding")
        //checks if the player clicks on a base node with a base part selected
        {
            Buildhere();
            //Calls the function to place the tower on this node
        }
        else if (gameObject.tag == "TowerBaseNode" && buildingType.turretToBuild.tag == "Tower")
        //Checks if the player clicks on a tower node with a tower selected
        {
            Buildhere();
            //Calls the function to place the tower on this node
        }
        else
        {
            Debug.Log("This does not go here!");
            //Puts text in the log - placeholder until there is a popup implemented
        }

    }
    void OnMouseEnter()
    //When the mouse hovers over the collider
    {
        startColor = rend.material.color;
        //Saves the current colour for when the mouse leaves
        rend.material.color = hoverColor;
        //changes the material colour to a different colour specified in the inspector
    }

    void OnMouseExit()
    //When the mouse stops hovering on the collider
    {
        rend.material.color = startColor;
        //returns the colour to the previous saved colour
    }

    void Buildhere()
    {
        if (buildingType.turretToBuild != null && transform.childCount == 0)
        //checks if there is a building selected and the node isnt already in use
        {
            if (buildingType.turretToBuild.tag == "Tower")
            //Checks if the player is trying to build a tower
            {
                offset = buildingType.turretToBuild.GetComponent<BaseAffects>().height;
                //sets an offset value to ensure that the tower is placed at the correct height
            }
            GameObject newObject = Instantiate(buildingType.turretToBuild, transform.position, buildingType.turretToBuild.transform.rotation);
            //creates the new building
            newObject.transform.SetParent(this.transform);
            //Sets the node to be the parent of the new building
            newObject.transform.Translate(0, 0, offset);
            //sets the location to have the offset previously specified
            buildingType.DeselectTurret();
            //Deselects the building
        }
        else if (transform.childCount > 0)
        {
            Debug.Log("There is already something Here!");
            //Puts text in the log - placeholder until there is a popup implemented
        }
        else
        {
            Debug.Log("No Turret Selected");
            //Puts text in the log - placeholder until there is a popup implemented
        }
    }

}
