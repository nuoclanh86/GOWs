using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController.GOWs;
using UnityEngine;

public class ActionPhaseManager : MonoBehaviour
{
    [SerializeField] GameObject mainCharacterPrefab;
    GameObject mainCharacter;

    [SerializeField] MainPlayerManager mainPlayerManager;

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
        mainCharacter = Instantiate(mainCharacterPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
