using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]

public class snapshotCamera : MonoBehaviour
{
    Camera snapCam;
    int resWidth = 1920;
    int resHeight = 1080;

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 48);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }

        snapCam.gameObject.SetActive(false);

        // Call a function to delete old images on Awake
        DeleteOldSnapshots();
    }

    // ...

    void DeleteOldSnapshots()
    {
        // Define the directory where the snapshots are stored
        string snapshotDirectory = Path.Combine(Application.dataPath, "monosnapshots");

        // Check if the directory exists
        if (Directory.Exists(snapshotDirectory))
        {
            // Get all files with the ".png" extension in the directory
            string[] files = Directory.GetFiles(snapshotDirectory, "*.png");

            // Delete each file
            foreach (string file in files)
            {
                File.Delete(file);
            }

            Debug.Log("Deleted old snapshots.");
        }
    }



    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB48, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log("monoSnapshot taken!");
            snapCam.gameObject.SetActive(false);
        }
    }

   int snapshotCount = 0;

    string SnapshotName()
    {
        string fileName = string.Format("img{0}.png", snapshotCount);
        snapshotCount++;
        return Path.Combine(Application.dataPath, "snapshots", fileName);
    }

}
