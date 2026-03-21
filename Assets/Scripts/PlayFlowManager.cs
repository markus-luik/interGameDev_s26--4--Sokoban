using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayFlowManager : MonoBehaviour
{
    public static PlayFlowManager Instance;
    public int currentScene = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)//If game manager exists && it is not itself, destroy that other game manager
        {
            Debug.Log("Other PlayFlowManager detected, will destroy...");
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
    }
    
     void ReloadScene()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reloading scene...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log($"Current scene: {currentSceneIndex}");
        int nextSceneIndex = currentSceneIndex + 1;
        //Debug.Log($"Next scene: {nextSceneIndex}");
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("Loading next scene...");
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                nextSceneIndex = 0;
                Debug.Log("LAST scene! Loading 0th scene...");
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }

    void Update()
    {
        ReloadScene();
        LoadNextScene();
    }
}


