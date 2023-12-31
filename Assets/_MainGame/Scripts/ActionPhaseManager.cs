using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using KinematicCharacterController.GOWs;
using UnityEngine;

public class ActionPhaseManager : MonoBehaviour
{
    [SerializeField] InGameUIController inGameUIController;
    [SerializeField] GameObject mainCharacterPrefab;
    public PlayerCamera playerCamera;
    Vector3 defaultRotateCamera;
    public Transform spawnPoint;
    GameObject mainPlayer;
    PlayerController mainPlayerController;

    int countKilled = 0;
    long totalMonsterOnScreen = 0;

    int mCheatHPForPlayer = 0;

    // private const string MouseXInput = "Mouse X";
    // private const string MouseYInput = "Mouse Y";
    // private const string MouseScrollInput = "Mouse ScrollWheel";
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

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

        // Tell camera to follow transform
        playerCamera.SetFollowTransform(mainPlayerController.CameraFollowPoint);

        // Ignore the character's collider(s) for camera obstruction checks
        playerCamera.IgnoredColliders.Clear();
        playerCamera.IgnoredColliders.AddRange(mainPlayer.GetComponentsInChildren<Collider>());

        //use default rotate of camera
        defaultRotateCamera = playerCamera.transform.rotation.eulerAngles;

        countKilled = 0;
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        // }

        HandleCharacterInput();
    }

    private void LateUpdate()
    {
        // Handle rotating the camera along with physics movers
        // if (playerCamera.RotateWithPhysicsMover && mainPlayerController.Motor.AttachedRigidbody != null)
        // {
        //     playerCamera.PlanarDirection = mainPlayerController.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * playerCamera.PlanarDirection;
        //     playerCamera.PlanarDirection = Vector3.ProjectOnPlane(playerCamera.PlanarDirection, mainPlayerController.Motor.CharacterUp).normalized;
        // }

        HandleCameraInput();
        if (mCheatHPForPlayer > 0)
        {
            mainPlayer.GetComponent<CharAttribute>().AddAttributeHealth(mCheatHPForPlayer);
            mainPlayer.GetComponent<CharAttribute>().RestoreHP(mCheatHPForPlayer);
            mCheatHPForPlayer = 0;
        }
    }

    private void HandleCameraInput()
    {
        // Create the look input vector for the camera
        // float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
        // float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
        // Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

        // Prevent moving the camera while the cursor isn't locked
        // if (Cursor.lockState != CursorLockMode.Locked)
        // {
        //     lookInputVector = Vector3.zero;
        // }

        // Input for zooming the camera (disabled in WebGL because it can cause problems)
        //         float scrollInput = -Input.GetAxis(MouseScrollInput);
        // #if UNITY_WEBGL
        //         scrollInput = 0f;
        // #endif

        // Apply inputs to the camera
        // playerCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);
        bool lockRotationCamera = true;
        playerCamera.UpdateWithInput(Time.deltaTime, 0.0f, Vector3.zero, lockRotationCamera);

        // Handle toggling zoom level
        // if (Input.GetMouseButtonDown(1))
        // {
        //     playerCamera.TargetDistance = (playerCamera.TargetDistance == 0f) ? playerCamera.DefaultDistance : 0f;
        // }
    }

    private void HandleCharacterInput()
    {
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

        // Build the CharacterInputs struct
        characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
        characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
        characterInputs.CameraRotation = playerCamera.Transform.rotation;
        characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
        characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.C);
        characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.C);

        // Apply inputs to character
        mainPlayerController.SetInputs(ref characterInputs);
    }

    public void UpdateHPMainPlayerBar(float val)
    {
        inGameUIController.hpFill.value = val;
    }
    public void UpdateMonsterKilled(int val = 1)
    {
        countKilled += val;
        inGameUIController.UpdateMonsterKilled(countKilled);
    }
    public void UpdateTotalMonsterOnScreen(int val)
    {
        totalMonsterOnScreen += val;
        inGameUIController.UpdateTotalMonsterOnScreen(totalMonsterOnScreen);
    }

    public void PauseGame(bool isPlayerDead = false)
    {
        inGameUIController.PauseGame(isPlayerDead);
    }

    public GameObject GetMainPlayer()
    {
        return mainPlayer;
    }

    public void CheatHPForPlayer(int cheatHPval)
    {
        Debug.Log("[GOWs] CheatHPForPlayer : " + cheatHPval);
        mCheatHPForPlayer = cheatHPval;
    }
}
