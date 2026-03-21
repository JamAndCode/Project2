using UnityEngine;

public class TestGazeInteraction : MonoBehaviour
{

    public Material gazeStartMaterial;
    public Material gazeStayMaterial;
    public Material gazeExitMaterial;

    public void SetStartMaterial()
    {
        GetComponent<Renderer>().material = gazeStartMaterial;
    }

    public void SetStayMaterial()
    {
        GetComponent<Renderer>().material = gazeStayMaterial;
    }

    public void SetExitMaterial()
    {
        GetComponent<Renderer>().material = gazeExitMaterial;
    }
}
