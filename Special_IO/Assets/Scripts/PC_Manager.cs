using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Manager : MonoBehaviour
{
    public GameObject Target;
    public GameObject normalscreen;
    public GameObject gamescreen;
    public List<GameObject> targets;

    public GameObject GameOverScreen;

    public float Target_Amount;
    public float Spawn_Cooldown;

    private bool TargetsSpawned;
    public bool GameEnded;
    public bool Spawning;
    private void Start()
    {
        TargetsSpawned = false;
        GameEnded = false;
    }

    private void Update()
    {
        if (TargetsSpawned && !GameEnded && targets.Count.Equals(0))
        {
                FindObjectOfType<SoundManagerScript>().PlaySFX(5);
                GameOverScreen.SetActive(true);
                GameEnded = true;
        }
    }
    IEnumerator SpawnTargets()
    {
        if (Spawning)
        {
            for (int i = 0; i < Target_Amount; i++)
            {
                yield return new WaitForSecondsRealtime(Spawn_Cooldown);
                if (Spawning && gamescreen.activeInHierarchy)
                {
                    GameObject newtarget = Instantiate(Target);
                    targets.Add(newtarget);
                }
            }
            Spawning = false;
        }
        if (!Spawning)
        {
            TargetsSpawned = true;
        }
        
        
    }
    public void Activate_Game()
    {
        normalscreen.SetActive(false);
        gamescreen.SetActive(true);
        Spawning = true;
        StartCoroutine(SpawnTargets());
    }
    public void Deactivate_Game()
    {
        normalscreen.SetActive(true);
        gamescreen.SetActive(false);
        GameOverScreen.SetActive(false);
        TargetsSpawned = false;
        GameEnded = false;
        DestroyTargets();
    }
    public void RestartGame()
    {
        GameOverScreen.SetActive(false);
        TargetsSpawned = false;
        GameEnded = false;
        Spawning = true;
        StartCoroutine(SpawnTargets());
    }
    public void DestroyTargets()
    {
        targets.Clear();
        TargetScript[] targets_to_destroy = FindObjectsOfType<TargetScript>();
        foreach (TargetScript target in targets_to_destroy)
        {
            target.DestroySelf();
        }
       
    }
}

