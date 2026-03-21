using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    public int currentScene = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)//If game manager exists && it is not itself, destroy that other game manager
        {
            Debug.Log("Other Scene Manager detected, will destroy.");
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void Update()
    {
        ReloadScene();
    }
}


