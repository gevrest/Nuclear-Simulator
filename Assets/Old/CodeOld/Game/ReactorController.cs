using UnityEngine;
using UnityEngine.UI;

public class ReactorController : MonoBehaviour
{

    public GameObject ControlRods;
    public Transform PumpFan;
    public Slider ReactorSlider;
    public Slider PumpSlider;
    public RectTransform NuclearIcon;

    private float ReactorPower;
    private float PumpPower;

    // Start is called before the first frame update
    void Start()
    {
        ControlRods.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        ReactorPower = ReactorSlider.value;
        ControlRods.GetComponent<Transform>().position = new Vector3 (0, ReactorPower, 0);

        PumpPower = PumpSlider.value;
        PumpFan.Rotate(new Vector3 (0, PumpPower, 0) * 500 * Time.deltaTime);

        NuclearIcon.Rotate(new Vector3(0, 0, -1) * 250 * Time.deltaTime);

    }
}