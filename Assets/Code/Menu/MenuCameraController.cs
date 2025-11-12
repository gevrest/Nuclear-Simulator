using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{

    public Transform MenuCamera;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MenuCamera.Rotate(new Vector3(0, 1, 0) * RotateSpeed * Time.deltaTime);
    }
}
