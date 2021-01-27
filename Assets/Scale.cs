using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        direction.y = 0;
    }
}
