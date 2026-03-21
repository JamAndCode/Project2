using UnityEngine;

public class StartScreenUI : MonoBehaviour
{

    public GameObject scoreUI;

    public PeopleSpawner ps;
    public void BeginGame()
    {
        //hide all start screenui
        GameObject[] startUIObjects = GameObject.FindGameObjectsWithTag("StartUI");
        foreach (GameObject obj in startUIObjects)
        {
            obj.SetActive(false);
        }
        //displays all ui score cards
        scoreUI.SetActive(true);
        //start spawners
        ps.StartSpawning();
    }
}
