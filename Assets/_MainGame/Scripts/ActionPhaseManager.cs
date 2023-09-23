using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController.GOWs;
using UnityEngine;

public class ActionPhaseManager : MonoBehaviour
{
    [SerializeField] GameObject mainCharacterPrefab;
    public PlayerCamera playerCamera;
    public Transform spawnPoint;
    GameObject mainPlayer;
    PlayerController mainPlayerController;

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
        mainPlayer = Instantiate(mainCharacterPrefab, spawnPoint.position, spawnPoint.rotation);

        mainPlayerController = mainPlayer.GetComponent<PlayerController>();
        playerCamera.SetFollowTransform(mainPlayerController.CameraFollowPoint);
        // Ignore the character's collider(s) for camera obstruction checks
        playerCamera.IgnoredColliders.Clear();
        playerCamera.IgnoredColliders.AddRange(mainPlayer.GetComponentsInChildren<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
