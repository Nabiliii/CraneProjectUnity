using UnityEngine;
using System.IO;

public class krok_GlobalPosition : MonoBehaviour
{
    public Transform endEffector; // Assign the end effector's transform in the Inspector
    private string logFileName = "C:\\crane_ship\\crane_ship\\Assets\\Annotations\\ROV_Pose.txt";
    private int currentIndex = 0; // Initialize the index

    void Start()
    {
        // Create or open the log file for writing
        using (StreamWriter writer = new StreamWriter(logFileName, false))
        {
            // Write the names of the elements in the first line
            writer.WriteLine(" x ; y ; z ; pith ;  yaw ; roll ");
            writer.WriteLine("");
        }
    }

    void Update()
    {
        // Check if the end effector transform is assigned and the Space key is pressed
        if (endEffector != null && Input.GetKeyDown(KeyCode.Space))
        {
            // Get the global (world) position of the end effector
            Vector3 globalPosition = endEffector.position;
            
            // Get the global (world) rotation of the end effector
            Quaternion globalRotation = endEffector.rotation;

            // Create or open the log file for writing
            using (StreamWriter writer = new StreamWriter(logFileName, true))
            {
                // Write the global position and rotation with an index
                string logMessage = string.Format("{0:F2}; {1:F2}; {2:F2}; {3:F2}; {4:F2}; {5:F2}",
                    globalPosition.x, globalPosition.y, globalPosition.z,
                    globalRotation.eulerAngles.x, globalRotation.eulerAngles.y, globalRotation.eulerAngles.z);
                writer.WriteLine(logMessage);



                // Increment the index for the next line
                currentIndex++;
            }
        }
        else if (endEffector == null)
        {
            Debug.LogError("ROV transform is not assigned.");
        }
    }
}
