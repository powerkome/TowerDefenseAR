using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bin_ScoreManager : MonoBehaviour
{
    public Text killText;
    int killNumber = 0;

    void Start()
    {
        killText.text = "Drone Kill : " + killNumber;
    }

    public void AddKillDrone()
    {
        killNumber++;
        killText.text = "Drone Kill : " + killNumber;
    }
}
