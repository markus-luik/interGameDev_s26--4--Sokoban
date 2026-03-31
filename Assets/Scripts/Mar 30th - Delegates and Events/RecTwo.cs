using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecTwo : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        BroadcasterObject.OnBroadcastTwo += OnBroadcastTwoListener; //Subscribe
        BroadcasterObject.OnSpaceBar += OnSpaceBarListener; //Subscribe
    }

    private void OnDisable()
    {
        BroadcasterObject.OnBroadcastTwo -= OnBroadcastTwoListener; //Unsubscribe
        BroadcasterObject.OnSpaceBar -= OnSpaceBarListener; //Unsubscribe
    }

    void OnSpaceBarListener(int x, int y)
    {
        int newX = Random.Range(x, y);
        int newY = newX;
        transform.localScale = new Vector3(newX,newY);
    }

    void OnBroadcastTwoListener()
    {
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
