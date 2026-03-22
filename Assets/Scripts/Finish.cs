using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool PlayerInFinish = false;
    private GameObject _playManagerGameObject;
    private PlayManager _playManager;

    void Awake()
    {
        _playManagerGameObject = GameObject.FindWithTag("PlayManager");
        _playManager = _playManagerGameObject.GetComponent<PlayManager>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Player entered finish.");
            _playManager.ReportFinishEnter();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Player exited finish.");
            _playManager.ReportFinishExit();
        }
    }
}
