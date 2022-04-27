using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delaySceneManager = 2f;

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lucky you, this won't kill you");
                break;
            case "Finish":
                NextSceneRoutine();
                break;
            case "Fuel":
                Debug.Log("Fuel added");
                break;
            default:
                CrashRoutine();
                break;
        }
        
    }

    void CrashRoutine ()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delaySceneManager);
    }

    void NextSceneRoutine ()
    {
        GetComponent<Rigidbody>().mass = 9999;
        GetComponent<Movement>().enabled = false;
        Invoke ("LoadNextScene", delaySceneManager);
    }
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        int nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        GetComponent<Movement>().enabled = false;
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }

}
