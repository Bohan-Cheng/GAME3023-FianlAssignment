using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_RandomBattle : MonoBehaviour
{
    [SerializeField] Animation Anim_Flash;

    [SerializeField] int MinSteps = 10;
    [SerializeField] int MaxSteps = 30;
    private int EncounterStep = 0;
    private float CurrentStep = 0;
    public bool ShouldCount = false;

    private Vector2 LastPosition;

    // Start is called before the first frame update
    void Start()
    {
        EncounterStep = Random.Range(MinSteps, MaxSteps);
    }

    public void SetLastPosition()
    {
        gameObject.transform.position = LastPosition;
    }

    public void AddStep()
    {
        if (ShouldCount)
        {
            if (CurrentStep < EncounterStep)
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
    }

    void DoEncounter()
    {
        GetComponentInParent<PlayerCharacterController>().IsPaused = true;
        LastPosition = gameObject.transform.position;
        Anim_Flash.Play();
        Invoke("StopFlash", 1.5f);
    }

    void StopFlash()
    {
        Anim_Flash.Stop();
        SceneManager.LoadScene("Map_Battle");
    }
}
