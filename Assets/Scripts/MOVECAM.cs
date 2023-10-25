using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVECAM : MonoBehaviour
{
    public Transform CameraPos;

    private void Update()
    {
        transform.position = CameraPos.position;
    }
}
