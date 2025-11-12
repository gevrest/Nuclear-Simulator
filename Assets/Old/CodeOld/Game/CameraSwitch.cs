using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public Camera reactor_cam;
    public AudioListener reactor_listener;
    public Camera transformator_cam;
    public AudioListener transformator_listener;
    public Canvas transformator_interface;

    // Start is called before the first frame update
    void Start()
    {
        reactor_cam = GetComponent<Camera>();
        reactor_cam = Camera.main;
        reactor_cam.enabled = true;
        reactor_listener.enabled = true;
        transformator_cam.enabled = false;
        transformator_listener.enabled = false;
        transformator_interface.enabled = false;
    }

    // Update is called once per frame
    public void SwitchCamera()
    {
        reactor_cam.enabled = !reactor_cam.enabled;
        reactor_listener.enabled = !reactor_listener.enabled;
        transformator_cam.enabled = !transformator_cam.enabled;
        transformator_listener.enabled = !transformator_listener.enabled;
        transformator_interface.enabled = !transformator_interface.enabled;
    }
}
