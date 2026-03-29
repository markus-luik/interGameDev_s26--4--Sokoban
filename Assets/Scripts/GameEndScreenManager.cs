using UnityEngine;
using TMPro;

public class GameEndScreenManager : MonoBehaviour
{
    public static GameEndScreenManager Instance;
    
    [SerializeField] private TMP_Text bigtext;
    [SerializeField] private TMP_Text smallText;
    
    //--------------------------------- AWAKE
    //Runs first
    //Makes sure only ONE GameEndScreenManager exists
    private void Awake()
    {
        //Makes self into Singleton
        if (Instance != null && Instance != this)//If game manager exists && it is not itself, destroy that other game manager
        {
            Debug.Log("Other GameEndScreenManager detected, will destroy...");
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
    /// Updates finishing text text according to where the player is 
    /// </summary>
    /// <param name="currentLvl">Current level player is on</param>
    /// <param name="nextLvl">Next level player will be on</param>
    /// <param name="finalLevel">YES if player is on final level</param>
    /// <returns></returns>
    public void UpdateTextContent(int currentLvl, int nextLvl, bool finalLevel)
    {
        if(bigtext == null || smallText == null)
        {
            Debug.Log("GameEndScreen not properly set up! Big and small text don't exist.");
            return;
        }
        if (!finalLevel)
        {
            bigtext.text = $"Level {currentLvl} finished!";
            smallText.text = $"Press SPACE to continue.";
        }
        else
        {
            bigtext.text = $"All levels finished!";
            smallText.text = $"Press SPACE to restart game.";
        }
    }
    //---------------------------------

}

