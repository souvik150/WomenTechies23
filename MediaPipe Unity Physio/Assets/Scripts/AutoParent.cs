using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParent : MonoBehaviour
{
    private PoseDataHolder poseDataHolder;
    [SerializeField]
    private int boneNumber;


    // Start is called before the first frame update
    void Start()
    {
        poseDataHolder = GameObject.Find("Pose Data Holder").GetComponent<PoseDataHolder>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.parent == null && poseDataHolder.points[boneNumber + 1] != null)
        {
            transform.SetParent( poseDataHolder.points[boneNumber + 1], false);
        }
    }
}
