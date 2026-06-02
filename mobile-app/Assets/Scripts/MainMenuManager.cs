using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuManager : MonoBehaviour
{
    // This function will be linked to your "Start Measuring" button
    public void LoadARScene()
    {
        // Make sure the spelling matches your actual AR scene name!
        SceneManager.LoadScene("SampleScene"); 
    }

    // This function will eventually connect to Laravel/NeonDB
    public void ViewRecords()
    {
        Debug.Log("Connecting to Laravel API to fetch NeonDB records...");
        // We will add the database fetch logic here later
    }
}