using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    [Header("End Points")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [Header("Colors")]
    [SerializeField] private Color unstretchedColor;
    [SerializeField] private Color stretchedColor;


    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, startPoint.position + new Vector3(0, 0, -10f));
        lineRenderer.SetPosition(1, endPoint.position + new Vector3(0, 0, -10f));
    }

    public void ChangeColor(float currentDistance, float maxDistance)
    {
        // bad naming convention but it's punny
        float coLerp = currentDistance / maxDistance;
        Debug.Log(coLerp);
        Color currentColor = Color.Lerp(unstretchedColor, stretchedColor, coLerp);
        Debug.Log(currentColor);
        //lineRenderer.startColor = currentColor;
        //lineRenderer.endColor = currentColor;

        Gradient tempGradient = new Gradient();

        GradientColorKey[] tempColorKeys = new GradientColorKey[2];
        tempColorKeys[0] = new GradientColorKey(currentColor, 0);
        tempColorKeys[1] = new GradientColorKey(currentColor, 1);

        tempGradient.colorKeys = tempColorKeys;

        lineRenderer.colorGradient = tempGradient;
    }
}
