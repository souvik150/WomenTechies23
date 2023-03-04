using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckRotationGameController : MonoBehaviour
{
    [SerializeField] private PoseDataHolder PoseDataHolder;

    [SerializeField] private Vector3 nosePosition;
    [SerializeField] private Vector3 leftEarPosition;
    [SerializeField] private Vector3 rightEarPosition;

    [SerializeField] private Vector3 directionVector;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nosePosition = PoseDataHolder.points[0 + 1].transform.position;
        leftEarPosition = PoseDataHolder.points[7 + 1].transform.position;
        rightEarPosition = PoseDataHolder.points[8 + 1].transform.position;

        Vector3 middllePosition = Vector3.Lerp(leftEarPosition, rightEarPosition, 0.5f);
        directionVector = nosePosition - middllePosition;

        angle = Vector3.Angle(-Vector3.forward, directionVector);
    }
}
