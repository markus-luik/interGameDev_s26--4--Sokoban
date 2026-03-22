using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;
    //Scene variables
        private int currentSceneIndex = 0;
        private int nextSceneIndex = 0;
    //Finishing logic
        private bool playerFinished = false;

    //--------------------------------- UPDATE
    void Update()
    {
        ReloadScene();
        LoadNextScene();
        if (playerFinished == true)
        {
            Debug.Log("Ahahahaha!");
        }
    }
    //---------------------------------
    
    //--------------------------------- AWAKE
        //Runs first
        //Makes sure only ONE playflowmanager exists
    private void Awake()
    {
        if (Instance != null && Instance != this)//If game manager exists && it is not itself, destroy that other game manager
        {
            Debug.Log("Other PlayManager detected, will destroy...");
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
    }
    //---------------------------------
    
    //--------------------------------- CUSTOM SCRIPTS
    /// <summary>
    /// Loads next scene in build list IF player has finished the current level.
    /// If no next scene, restarts from the beginning
    /// </summary>
    void LoadNextScene()
    {
        if(playerFinished && currentSceneIndex > 0 || currentSceneIndex == 0 || Input.GetKey(KeyCode.LeftShift)){ //If player finished in one of the levels OR player is on start screen OR holding Left Shift overrride
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
                ReportFinishExit(); //exits finish bool
            }
        }
    }
    
    /// <summary>
    /// Restarts scene when Left-Shift and R have been pressed
    /// </summary>
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

    /// <summary>
    /// Reports player entering finish from different script. Used in Finish.cs script.
    /// </summary>
    public void ReportFinishEnter()
    {
        playerFinished = true;
    }
    /// <summary>
    /// Reports player exiting finish from different script. Used in Finish.cs script.
    /// </summary>
    public void ReportFinishExit()
    {
        playerFinished = false;
    }
    //---------------------------------
    
    //--------------------------------- ON SCENE LOADED
    //Runs third
    //Sets scene index variables 
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"OnSceneLoaded: {scene.name}");
        Debug.Log(mode);
        Debug.Log("--Setting scene indexes--");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"Current scene: {currentSceneIndex}");
        nextSceneIndex = currentSceneIndex + 1;
        Debug.Log($"Next scene: {nextSceneIndex}");
        Debug.Log("----");
    }
    //---------------------------------
    
    //---------------------------------ON ENABLE & ON DISABLE
    //Runs second
    //Adds OnSceneLoaded to event list
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //Called when the game is terminated - Not sure why this is needed
    //Removed OnSceneLoaded from event list
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //---------------------------------
}


