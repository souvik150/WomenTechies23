using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HipFlexionGameController : MonoBehaviour
{
    [Header("Object References")]
    public TMP_Text angleTextL;
    public TMP_Text angleTextR;
    public ScorePopup scorePopup;

    [Header("Stretch Distances")]
    public float minRotation = 70f;

    [Header("Score Counter")]
    public float score = 0f;
    public TMP_Text scoreText;

    private bool isLeft = false;

    [SerializeField] private PoseDataHolder PoseDataHolder;

    [SerializeField] private Vector3[] kneeJointsL;
    [SerializeField] private Vector3[] kneeJointsR;

    [SerializeField] private Vector3[] kneeDirectionL;
    [SerializeField] private Vector3[] kneeDirectionR;

    public float angleL;
    public float angleR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        kneeJointsL = new Vector3[]{
            PoseDataHolder.points[23 + 1].transform.position,
            PoseDataHolder.points[25 + 1].transform.position,
            PoseDataHolder.points[27 + 1].transform.position
        };

        kneeJointsR = new Vector3[]{
            PoseDataHolder.points[24 + 1].transform.position,
            PoseDataHolder.points[26 + 1].transform.position,
            PoseDataHolder.points[28 + 1].transform.position
        };

        kneeDirectionL = new Vector3[] { kneeJointsL[0] - kneeJointsL[1], kneeJointsL[2] - kneeJointsL[1] };
        kneeDirectionR = new Vector3[] { kneeJointsR[0] - kneeJointsR[1], kneeJointsR[2] - kneeJointsR[1] };

        angleL = Vector3.Angle(kneeDirectionL[0], kneeDirectionL[1]);
        angleR = Vector3.Angle(kneeDirectionR[0], kneeDirectionR[1]);

        angleTextL.text = angleL.ToString("0.0");
        angleTextR.text = angleR.ToString("0.0");

        if (isLeft && angleR <= 100)
        {
            isLeft = false;
            score++;
            scoreText.text = "Score: " + score;
            scorePopup.PopUpText();

        }

        else if (!isLeft && angleL <= 100)
        {
            isLeft = true;
        }


    }
}
