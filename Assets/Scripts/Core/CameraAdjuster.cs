using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    [SerializeField] 
    private Minefield minefield;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = minefield.Height / 2f + 2.5f;
        transform.position = new Vector3(minefield.Width / 2f - .5f, minefield.Height / 2f - .5f, -10);
    }
}
