using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_taking : MonoBehaviour
{
    public snapshotCamera snapCam;
    //public Drive info_saver;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            snapCam.CallTakeSnapshot(); 
            //info_saver.saveinfo();
        }
    }
}
