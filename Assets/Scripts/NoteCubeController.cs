using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > 10)
        {            
            Destroy(this);
        } 
    }
}
