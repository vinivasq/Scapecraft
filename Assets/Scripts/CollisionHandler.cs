using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delaySceneManager = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;

    [SerializeField] ParticleSystem successVFX;
    [SerializeField] ParticleSystem crashVFX;
   
    AudioSource audioSource;
    
    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) { return; } // se colidir em alguma coisa enquanto isTransitioning for true, ira retornar ao inves de avançar e executar o switch novamente, evitando que o jogador possa se mexer ou toque outros SFXs equanto isTransitioning for true.

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lucky you, this wont kill you");
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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashVFX.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delaySceneManager);
    }

    void NextSceneRoutine ()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successVFX.Play();
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
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }

}
