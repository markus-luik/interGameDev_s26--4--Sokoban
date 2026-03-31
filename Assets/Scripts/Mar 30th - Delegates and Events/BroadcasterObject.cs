using UnityEngine;

public class BroadcasterObject : MonoBehaviour
{
    public delegate void BroadcastDelegate(); //A type of parameter that can hold classes
    public static event BroadcastDelegate OnBroadcastOne; //Declares broadcast event
    public static event BroadcastDelegate OnBroadcastTwo;
    
    public delegate void SpaceBarDelegate(int x, int y);
    public static event SpaceBarDelegate OnSpaceBar;

    [Header("NUMBERS")]
    [SerializeField, Range(0,10)] private int x = 1;
    [SerializeField, Range(0,10)] private int y = 10;
    
    void ReadInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpaceBar?.Invoke(x,y); //Passes on int 1 and 7; can pass along ANYTHING
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W was pressed!");
            OnBroadcastOne?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A was pressed!");
            OnBroadcastTwo?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S was pressed!");
            OnBroadcastOne?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed!");
            OnBroadcastTwo?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
}
