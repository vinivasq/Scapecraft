using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lucky you, this won't kill you");
                break;
            case "Finish":
                Debug.Log("Congrats, you landed successfully");
                break;
            case "Fuel":
                Debug.Log("Fuel added");
                break;
            default:
                Debug.Log("You Crashed :(");
                break;
        }
        
    }

}
