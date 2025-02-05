using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentDataManager : MonoBehaviour
{
    //InputField for saving student Details
    public InputField nameInput;
    public InputField ageInput;
    public InputField studentNumberInput;
    public InputField studentSection;

    //Search Inputfield 
    public InputField searchInput;

    public Text resultText;
    //Save Student Data
    public void saveStudentData()
    {
        string studentName = nameInput.text;
        int age, studentNumber;
        string Section = studentSection.text;
        //Check  if fields are not Empty and parse values
        if (!string.IsNullOrEmpty(studentName) &&
            int.TryParse(ageInput.text, out age) &&
           int.TryParse(studentNumberInput.text, out studentNumber) &&
           !string.IsNullOrEmpty(Section))
        {

            //Save data in PlayerPrefs
            PlayerPrefs.SetInt(studentName + "Age", age);
            PlayerPrefs.SetInt(studentName + "studentNumber", studentNumber);
            PlayerPrefs.SetString(studentName + "Student Section", Section);
            PlayerPrefs.Save();
            Debug.Log("Student Data Saved: " + studentName);
        }
        else
        {
            Debug.Log("InvalidInput");
        }
    }
    //Loading Student Data
    public void LoadStudentData()
    {
        string studentName = searchInput.text;
        if (PlayerPrefs.HasKey(studentName + "Age"))
        {
            int age = PlayerPrefs.GetInt(studentName + "Age");
            int studentNumber = PlayerPrefs.GetInt(studentName + "StudentNumber");
            string Section = PlayerPrefs.GetString(studentName + "student Section");
            resultText.text = $"Name: {studentName}\nAge: {age}\nSN: {studentNumber}\nSection: {Section}m";
        }
        else
        {
            resultText.text = "Student not Found";
        }
    }
}
