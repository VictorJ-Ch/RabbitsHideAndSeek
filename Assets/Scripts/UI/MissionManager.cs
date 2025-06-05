using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public GameObject missionA;
    void Start()
    {
        missionA.SetActive(true);
        Invoke("ShuttingMissionDown", 10f);
    }

    void ShuttingMissionDown()
    {
        missionA.SetActive(false);
    }
}
