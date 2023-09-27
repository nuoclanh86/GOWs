using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMove : MonoBehaviour
{
    public Vector3 moveDir = Vector3.zero;
    public GameObject maxPos;
    Vector3 minPos;
    public float timeMove = 5.0f;
    public float speedMove = 5.0f;
    Timer timerMove;
    bool moveForward = true;

    // Start is called before the first frame update
    void Start()
    {
        timerMove = new Timer();
        timerMove.SetDuration(timeMove);
        timerMove.Reset();
        minPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
            this.transform.position = Vector3.MoveTowards(this.transform.position, maxPos.transform.position, speedMove * Time.deltaTime);
        else
            this.transform.position = Vector3.MoveTowards(this.transform.position, minPos, speedMove * Time.deltaTime);

        if (timerMove.IsDone())
        {
            moveForward = !moveForward;
            timerMove.Reset();
        }
        else
        {
            timerMove.Update(Time.deltaTime);
        }
    }
}
