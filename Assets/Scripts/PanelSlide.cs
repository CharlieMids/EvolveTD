using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelSlide : MonoBehaviour
{
    public Transform slideOut;
    public Transform slideIn;
    public bool moveActive = false;
    private Vector2 slideOutTarget;
    private Vector2 slideInTarget;

    //Setting the variables needed in this script

    void Start()
    {
        Vector2 slideOutTarget = (Vector2)slideOut.position;
        Vector2 slideInTarget = (Vector2)slideIn.position;
        //Sets the 2D locations that the UI element will go from and to
    }

    public IEnumerator SlideOutCo()
    // Declares a coroutine
    {
        float travelTime = 1;
        float currentTime = 0;
        float normalizedTime;
        //Declares used variables
        while (currentTime <= travelTime)
        //Checks if the UI has finished travelling
        {
            currentTime += Time.deltaTime;
            //Adds time to the currentTime so that frames dont affect the movement
            normalizedTime = currentTime / travelTime;
            transform.position = Vector2.Lerp(transform.position, slideOut.position, normalizedTime);
            //Slides the elements around smoothly
            yield return null;
        }
        yield return null;
    }
    public IEnumerator SlideInCo()
    // Declares a coroutine
    {
        float travelTime = 1;
        float currentTime = 0;
        float normalizedTime;
        //Declares used variables
        while (currentTime <= travelTime)
        {
            currentTime += Time.deltaTime;
            //Adds time to the currentTime so that frames dont affect the movement
            normalizedTime = currentTime / travelTime;
            transform.position = Vector2.Lerp(transform.position, slideIn.position, normalizedTime);
            //Slides the elements around smoothly
            yield return null;
        }
        yield return null;
    }
}
