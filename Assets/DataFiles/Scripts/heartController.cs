using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{
    private InstantTrackingController trackerScript;
    //private GameObject ButtonParents;
    // Start is called before the first frame update
    void Start()
    {
        trackerScript = GameObject.Find("Controller").gameObject.GetComponent<InstantTrackingController>(); // to access the InstantTrackingController script
        //ButtonParents = GameObject.Find("Buttons Parent");

        trackerScript._gridRenderer.enabled = false;
       // ButtonParents.SetActive(false);
        
    }

    void onEnable()
    {
        trackerScript._gridRenderer.enabled = false;
        //ButtonParents.SetActive(false);
    }

    void OnDisable()
    {
       // ButtonParents.SetActive(true);
    }

}
