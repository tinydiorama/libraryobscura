using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class DayTimeController : MonoBehaviour, iDataPersistence
{
    [SerializeField] private const float secondsInDay = 86400f;

    [SerializeField] private Color nightLightColor;
    [SerializeField] private Color dayLightColor = Color.white;
    [SerializeField] private AnimationCurve nightTimeCurve;
    [SerializeField] private float timeScale = 60f;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject timeArrow;

    private float time;
    public int days { get; private set; }
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private float Hours
    {
        get { return time / 3600f; }
    }


    private void Update()
    {
        if ( time < secondsInDay && ! gm.isPaused)
        {
            time += Time.deltaTime * timeScale;


            Vector3 currentEuler = timeArrow.transform.rotation.eulerAngles;
            float rotation = currentEuler.z;

            float t = Hours / 24f;
            float newRotation = Mathf.Lerp(90, -90, t);

            //set rotation back onto transform
            timeArrow.transform.rotation = Quaternion.Euler(new Vector3(currentEuler.x, currentEuler.y, newRotation));

            float v = nightTimeCurve.Evaluate(Hours);
            Color c = Color.Lerp(dayLightColor, nightLightColor, v);
            globalLight.color = c;
        }
    }

    public string getTime()
    {
        float t = Hours / 24f;
        float actualTime = Mathf.Lerp(6, 24, t);

        int actualHour = (int)Mathf.Floor(actualTime);
        float actualMinute = Mathf.Floor((actualTime % 1) * 60);
        float trueHour;
        string amPm;
        if ( actualHour <= 12 )
        {
            trueHour = actualHour;
            amPm = "am";
        } else
        {
            trueHour = actualHour - 12;
            amPm = "pm";
        }
        return trueHour.ToString() + ":" + actualMinute.ToString() + amPm;
    }

    public void NextDay()
    {
        time = 0;
        days += 1;
    }

    public void LoadData(GameData data)
    {
        this.days = data.days;
    }

    public void SaveData(ref GameData data)
    {
        data.days = this.days;
    }
}
