using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TMP_Text[] scoreUI;
    public static Score Instance;

    void Awake()
    {
        Instance = this;
    }
    
    public void IncreaseScore()
    {
        score++;
        foreach (TMP_Text obj in scoreUI)
        {
            obj.text = score.ToString();
        }
    }
}
