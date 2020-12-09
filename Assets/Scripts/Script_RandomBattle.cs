using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_RandomBattle : MonoBehaviour
{
    [SerializeField] int MinSteps = 10;
    [SerializeField] int MaxSteps = 30;
    [SerializeField] int EncounterStep = 0;
    [SerializeField] float CurrentStep = 0;
    [SerializeField] bool ShouldCount = false;

    // Start is called before the first frame update
    void Start()
    {
        EncounterStep = Random.Range(MinSteps, MaxSteps);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStep()
    {
        if(CurrentStep < EncounterStep)
        {
            CurrentStep += 0.01f;
        }
        else
        {
            CurrentStep = 0;
            EncounterStep = Random.Range(MinSteps, MaxSteps);
            DoEncounter();
        }
    }

    void DoEncounter()
    {
        SceneManager.LoadScene("Combat Scene");
    }
}
