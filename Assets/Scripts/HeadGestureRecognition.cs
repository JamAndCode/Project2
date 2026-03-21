using UnityEngine;

public class HeadGestureRecognition : MonoBehaviour
{
    private Vector3[] angles;
    private int index;
    private Vector3 centerAngle;
    public GameObject testObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetGesture();
    }

    // Update is called once per frame
    void Update()
    {
        angles [index] = Camera.main.transform.eulerAngles; //GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
        index++;
        if (index == 80)
        {
            CheckMovement();
            ResetGesture();
        }
    }

    void CheckMovement()
    {
        bool right = false, left = false, up = false, down = false;
        for (int i = 0; i < 80; i++)
        {
            //up and down (nodding)
            if (angles[i].x < centerAngle.x - 15.0f && !up)
            {
                up = true;
            }else if (angles[i].x > centerAngle.x + 15.0f && !down)
            {
                down = true;
            }

            //left and right (shaking)
            if (angles[i].y < centerAngle.y - 15.0f && !left)
            {
                left = true;
            }else if (angles[i].y > centerAngle.y + 15.0f && !right)
            {
                right = true;
            }
        }

        if (left && right)
        {
            testObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (up && down)
        {
            testObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void ResetGesture()
    {
        angles = new Vector3[80];
        index = 0;
        centerAngle = Camera.main.transform.eulerAngles; //GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
    }
}
