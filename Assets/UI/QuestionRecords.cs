using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionRecords : MonoBehaviour
{
    public Slider question1Slider,question2Slider,question3Slider,question4Slider,question5Slider;
    public int question1Value,question2Value,question3Value,question4Value,question5Value;
    public float time;
    public AirtableManager airtableManager;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetFloat("timetaken", "_value");
    }

    public void UpdateQuestionValue()
    {
        question1Value = (int)question1Slider.value;
        question2Value = (int)question2Slider.value;
        question3Value = (int)question3Slider.value;
        question4Value = (int)question4Slider.value;
        question5Value = (int)question5Slider.value;
        time = PlayerPrefs.GetFloat("timetaken");
    }

    public void CreateRecord()
    {
        airtableManager.question1 = question1Value.ToString();
        airtableManager.question2 = question2Value.ToString();
        airtableManager.question3 = question3Value.ToString();
        airtableManager.question4 = question4Value.ToString();
        airtableManager.question5 = question5Value.ToString();
        //airtableManager.time = time.ToString();
        airtableManager.CreateRecord();
    }
}
