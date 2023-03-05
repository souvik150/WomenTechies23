using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDataHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public GameObject[] pointObjects = new GameObject[32];

    [SerializeField]
    private GameObject pointListAnnotation;

    void Start()
    {
        //pointListAnnotation = GameObject.Find("Point List Annotation");
        //points = pointListAnnotation.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        points = pointListAnnotation.GetComponentsInChildren<Transform>();
    }
}
