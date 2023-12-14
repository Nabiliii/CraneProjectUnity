using UnityEngine;

public class MountainAlternator : MonoBehaviour
{
    public GameObject object1; // Assign your first object in the Unity inspector
    public GameObject object2; // Assign your second object in the Unity inspector

    private bool isObject1Active = true;
    private bool isObject2Active = false;
    private bool isNoneActive = false;

    private void Start()
    {
        // Ensure object1 is initially active, and object2 and none are inactive
        object1.SetActive(isObject1Active);
        object2.SetActive(isObject2Active);

        // Start a repeating method to alternate objects and none every 2 seconds
        InvokeRepeating("ToggleObjects", 0f, 2f); // 2 seconds for object1, 2 seconds for object2, and 2 seconds for none
    }

    private void ToggleObjects()
    {
        if (isObject1Active)
        {
            isObject1Active = false;
            isObject2Active = true;
        }
        else if (isObject2Active)
        {
            isObject2Active = false;
            isNoneActive = true;
        }
        else if (isNoneActive)
        {
            isNoneActive = false;
            isObject1Active = true;
        }

        object1.SetActive(isObject1Active);
        object2.SetActive(isObject2Active);
    }
}
