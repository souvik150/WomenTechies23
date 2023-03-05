using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeckRotationGameController : MonoBehaviour
{
    [Header("Object References")]
    public TMP_Text distanceText;
    public ScorePopup scorePopup;

    [Header("Stretch Distances")]
    public float minRotation = 70f;

    [Header("Score Counter")]
    public float score = 0f;
    public TMP_Text scoreText;
    public TMP_Text angleText;

    private bool isLeft = false;

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
    void FixedUpdate()
    {
        nosePosition = PoseDataHolder.points[0 + 1].transform.position;
        leftEarPosition = PoseDataHolder.points[7 + 1].transform.position;
        rightEarPosition = PoseDataHolder.points[8 + 1].transform.position;

        Vector3 middllePosition = Vector3.Lerp(leftEarPosition, rightEarPosition, 0.5f);
        directionVector = nosePosition - middllePosition;

        angle = Vector3.Angle(-Vector3.forward, directionVector);
        angleText.text = angle.ToString("0.0");

        if (isLeft && angle >= minRotation && directionVector.x > 0)
        {
            isLeft = false;
            score++;
            scoreText.text = "Score: " + score;
            scorePopup.PopUpText();

        }

        if (!isLeft && angle >= minRotation && directionVector.x < 0)
        {
            isLeft = true;
        }


    }

}
