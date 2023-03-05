using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShoulderStretchGameController : MonoBehaviour
{
    [Header("Object References")]
    public TMP_Text distanceText;
    public ScorePopup scorePopup;

    public GameObject handR;
    public GameObject handL;
    public LineConnector lineCon;

    [Header("Stretch Distances")]
    public float unstretchedDistance = 40f;
    public float stretchedDistance = 120f;

    [Header("Score Counter")]
    public float score = 0f;
    public TMP_Text scoreText;



    private float distance;

    private bool isStretched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(handL.transform.position, handR.transform.position);
        distanceText.text = distance.ToString();
        
    }

    private void FixedUpdate()
    {
        if (isStretched && distance < unstretchedDistance)
        {
            isStretched = false;
            score++;
            scoreText.text = "Score: " + score;
            scorePopup.PopUpText();
            
        }
        
        if (!isStretched && distance > stretchedDistance)
        {
            isStretched = true;
        }
        lineCon.ChangeColor(distance, stretchedDistance + 50);
    }
}
