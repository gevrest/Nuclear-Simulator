using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public Slider ReactorSlider;
    public Slider PumpSlider;
    public Text ReactorTemperature;
    public Text TurbineTemperature;
    public Text ReactorPressure;
    public TMP_Text Power;
    public Text Money;
    public GameObject ReactTempWarn;
    public GameObject TurbineTempWarn;
    public GameObject ReactPressWarn;
    public GameObject RepareWarning;
    public Text TemperatureReport;
    public Text PressureReport;
    public Text TurbineReport;
    public Text SystemInfo;
    public Image NuclearIcon;
    public GameObject DestroyedNotification;

    private float reactor_temperature;
    private float reactor_pressure;
    private float turbine_temperature;
    private float power;
    private float money;

    private string reactor_temp_report = " temperature is normal";
    private string reactor_press_report = " pressure is normal";
    private string turbine_temp_report = " temperature is normal";

    private bool turbine_working;

    // Start is called before the first frame update
    void Start()
    {
        reactor_temperature = 20f;
        reactor_pressure = 1f;
        turbine_temperature = 20f;
        power = 0f;
        money = 100f;
        turbine_working = true;

        RepareWarning.SetActive(false);
        DestroyedNotification.SetActive(false);
    }

    // Update is called once per 0,1 second
    void FixedUpdate()
    {
        reactor_temperature += ((4f + Random.Range(0.015f, 0.02f)) * ReactorSlider.value) - (0.5f * PumpSlider.value) - 0.2f;
        reactor_pressure += ((0.26f - Random.Range(0.015f, 0.02f)) * ReactorSlider.value) - (0.0325f * PumpSlider.value) - 0.01f;
        power = turbine_temperature * 5f - 100f;
        money += power / 100f;        

        if (PumpSlider.value == 1f)
        {
            if (turbine_temperature < (18f + (reactor_temperature / 8f)))
            {
                turbine_temperature += 0.35f;
            }
            else
            {
                turbine_temperature = 18f + (reactor_temperature / 8f);
            }
        }
        else
        {
            turbine_temperature -= 0.25f;
        }        

        if (reactor_temperature < 20f)
            reactor_temperature = 20f;

        if (reactor_pressure < 1f)
            reactor_pressure = 1f;

        if (turbine_temperature < 20f)
            turbine_temperature = 20f;

        ReactorTemperature.text = reactor_temperature.ToString("#") + "°Ñ";
        ReactorPressure.text = reactor_pressure.ToString("#.#") + "bar";
        TurbineTemperature.text = turbine_temperature.ToString("#") + "°C";
        Power.text = power.ToString("#") + "MW";
        Money.text = money.ToString("#") + "$";
    }

    // Update is called once per frame
    void Update()
    {

        if (reactor_temperature >= 2400f)
        {
            ReactTempWarn.SetActive(true);
            reactor_temp_report = " overheated";
        }            
        else
        {
            ReactTempWarn.SetActive(false);
            reactor_temp_report = " temperature is normal";
        }

        if (turbine_temperature >= 250f)
        {
            TurbineTempWarn.SetActive(true);
            turbine_temp_report = " overheated";
        }
        else
        {
            TurbineTempWarn.SetActive(false);
            turbine_temp_report = " temperature is normal";
        }

        if (reactor_pressure >= 160f)
        {
            ReactPressWarn.SetActive(true);
            reactor_press_report = " pressure is high";
        }
        else
        {
            ReactPressWarn.SetActive(false);
            reactor_press_report = " pressure is normal";
        }

        if (turbine_temperature >= 300f)
        {
            turbine_working = false;
        }

        if (!turbine_working) 
        { 
            PumpSlider.value = 0f;
            RepareWarning.SetActive(true);
            turbine_temp_report = " is broken";
        }
            
        TemperatureReport.text = "reactor" + reactor_temp_report;
        PressureReport.text = "reactor" + reactor_press_report;
        TurbineReport.text = "turbine" + turbine_temp_report;

        if (!turbine_working)
        {
            SystemInfo.text = "The system seriously damaged...";
            SystemInfo.color = Color.red;
            NuclearIcon.color = Color.red;
        }
        else if (reactor_temperature >= 2400f || reactor_pressure >= 160f || turbine_temperature >= 250f)
        {
            SystemInfo.text = "The system is overloaded...";
            SystemInfo.color = Color.yellow;
            NuclearIcon.color = Color.yellow;
        }
        else
        {
            SystemInfo.text = "All systems works normal...";
            SystemInfo.color = Color.green;
            NuclearIcon.color = Color.green;
        }

        if (reactor_temperature >= 2600f || reactor_pressure >= 200f)
        {
            DestroyedNotification.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void RepareTurbine()
    {
        if (money >= 10000f)
        {
            turbine_working = true;
            money -= 10000f;
            RepareWarning.SetActive(false);
            turbine_temperature = 20f;
        }
    }
}