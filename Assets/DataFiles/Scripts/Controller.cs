using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;


public class Controller : MonoBehaviour
{
    public InstantTracker Tracker; // to access the Instant Tracker object.
    private float heightAboveGround = 1.0f; // as we put our model above the video feed of the camera.
    private GridRenderer grid; // this will help us recodnize the ground surface
    private bool isTracking = false;
    public Button trackingControl; // with this btn we will turn the tracking on & off.
    public GameObject heartPrefab;

   
    public void Awake()
    {
        grid = GetComponent<GridRenderer>();
    }

    public void Update()
    {
        if (!isTracking) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            UnityEngine.Plane groundPlane = new UnityEngine.Plane(Vector3.up, Vector3.zero);
            float touchPos;
            if (groundPlane.Raycast(cameraRay, out touchPos))
            {
                Vector3 position = cameraRay.GetPoint(touchPos);
                Instantiate(heartPrefab, position, Quaternion.identity);
            }
        }
    }

    // this will be called when the btn is clicked for turning the tracking on & off
    public void StartTracker()
    {
        Debug.Log("StartTracker called");
        isTracking = !isTracking; //setting the value everytime btn is clicked
        if (isTracking) // enters if only its true.
         Tracker.SetState(InstantTrackingState.Tracking);  // it starts tracking  
        else
            Tracker.SetState(InstantTrackingState.Initializing); // goes into initialization i.e kinda stop tracking.   
    }
    
    
    public virtual void OnErrorLoading(int errorCode, string errorMessage)
    {
        Debug.LogError("Error Loading URL Resource!\nErrorCode: " + errorCode + "\nErrorMessage: " + errorMessage);
    }


    // Tracker events
    public virtual void OnTargetsLoaded()
    {
        Debug.Log("Targets loaded successfully.");
    }

    public void OnSceneRecognized(InstantTarget target)
    {
        Debug.Log("Enter the field of vision");
        SetScene(true);
    }

    // Not needed
    public void OnInitializationStarted(InstantTarget target)
    {
        Debug.Log("Enter Initialization Started");
    }

    // Not needed
    public void OnInitializationStopped(InstantTarget target)
    {
        Debug.Log("Enter Initialization Stopped");
    }

    public void OnSceneLost(InstantTarget target)
    {
        Debug.Log("\n Exit the field of vision");
        SetScene(false);
    }

    public void OnStateChanged(InstantTrackingState newState)
    {
        Debug.Log("\n State changes to " + newState);
        Tracker.DeviceHeightAboveGround = heightAboveGround;

        // To know when the tracking starts, color will change from blue to green.
        if(newState == InstantTrackingState.Tracking)
        {
            trackingControl.GetComponent<Image>().color = Color.green;
            isTracking = true;
        }
        else if(newState == InstantTrackingState.Initializing)
        {
            trackingControl.GetComponent<Image>().color = Color.blue;
            isTracking = false;
        }
    }

    private void SetScene(bool a)
    {
        grid.enabled = a;
        heartPrefab.GetComponent<Renderer>().enabled = a;
    }
}
