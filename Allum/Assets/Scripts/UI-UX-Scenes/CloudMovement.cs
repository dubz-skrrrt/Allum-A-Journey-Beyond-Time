using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private const float XCloudPosDestroy = 15f;
    private const float cloudMoveSpeed = 0.75f;
    public List<Transform> cloudList;
    private void Awake()
    {
        foreach (Transform cloud in this.gameObject.GetComponentInChildren<Transform>())
        {
            cloudList.Add(cloud);
        }
    }
    private void Update()
    {
        cloudMovement();
    }

    private void cloudMovement()
    {
        foreach (Transform clouds in cloudList)
        {
            clouds.position += new Vector3(1, 0, 0) * cloudMoveSpeed * Time.deltaTime;
            float RightMostXPos = -19f;
            
            if (clouds.position.x > XCloudPosDestroy)
            {
                for (int i = 0; i < cloudList.Count; i++)
                {
                    if (cloudList[i].position.x < RightMostXPos)
                    {
                        RightMostXPos = cloudList[i].position.x;
                    }
                }

                float cloudwidthHalf = 4f;
                clouds.position = new Vector3(RightMostXPos + cloudwidthHalf, clouds.position.y, clouds.position.z);
            }
        }
    }
}
