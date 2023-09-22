using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhaseManager : MonoBehaviour
{
    [SerializeField] GameObject mainCharacterPrefab;
    public GameObject mainCharacter;

    private static ActionPhaseManager _instance;

    public static ActionPhaseManager GetInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
