using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]

public class RecOne : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void OnEnable()
    {
        Debug.Log("OnEnable");
        //Subscribes to event
        //
        BroadcasterObject.OnBroadcastOne += OnBroadcastOneListener; //When that BroadcaterObject event is called, OUR object's OnBroadcastOne event will be called 
    }

    void OnDisable()
    {
        //UnSubscribes from event
        BroadcasterObject.OnBroadcastOne -= OnBroadcastOneListener; //You should do this instinctively. Otherwise you might get an e
    }

    void OnBroadcastOneListener() //This function will subscribe to the BroadcasterObject's OnBroadcastOne event. Same name for consistency
    {
        Debug.Log($"{name} is subscribed!");
        ChangeColor();
    }

    private void Awake()
    {
        _spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    void ChangeColor()
    {
        _spriteRenderer.color = Random.ColorHSV();
    }
}
