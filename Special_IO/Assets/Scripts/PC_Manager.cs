using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Manager : MonoBehaviour
{
    public GameObject Target;
    public GameObject normalscreen;
    public GameObject gamescreen;
    public List<GameObject> targets;
    // Start is called before the first frame update

    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSecondsRealtime(1);
            Debug.Log($"Spawned {i}");
            GameObject newtarget = Instantiate(Target);
            targets.Add(newtarget);
        }
    }
    public void Activate_Game()
    {
        normalscreen.SetActive(false);
        gamescreen.SetActive(true);
        StartCoroutine(SpawnTargets());
    }
    public void Deactivate_Game()
    {
        normalscreen.SetActive(true);
        gamescreen.SetActive(false);
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }
}
