using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Manager : MonoBehaviour
{
    public GameObject Target;
    public GameObject normalscreen;
    public GameObject gamescreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(1);
            Debug.Log($"Spawned {i}");
        }
    }
    public void Activate_Game()
    {
        normalscreen.SetActive(false);
        gamescreen.SetActive(true);
        Debug.Log("test");
    }
    public void Deactivate_Game()
    {
        normalscreen.SetActive(true);
        gamescreen.SetActive(false);
    }
}
