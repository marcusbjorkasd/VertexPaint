﻿using UnityEngine;

public class MouseIndicator : MonoBehaviour
{
    private readonly int segments = 10;
    float xradius = 0.5f;
    float yradius = 0.5f;
    LineRenderer line;
    
    void Start()
    {
        //Create the Linerenderer
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments;
        line.useWorldSpace = false;
        //Setup the circle
        SetupCircle();
    }
    void Update()
    {
        // Raycast to see where the mouse is currently painting
        Ray worldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(worldRay, out hit, 500f))
        {
            //set the linerenders position and rotation to follow the mouse
            transform.position = hit.point;
            transform.rotation = Quaternion.FromToRotation(transform.forward, hit.normal) * transform.rotation;
        }
    }

    public void SetupCircle()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 2f;

        for (int i = 0; i < (segments + 1); i++)
        {
            //math to make the circle
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));
            angle += (360f / segments);
        }

    }
    public void OnValueChange(float value)
    {
        Debug.Log("hehe");
        xradius = value;
        yradius = value;
    }
     
    // functions that are called when we press the UI buttons.
    public void GreenColor()
    {
        line.startColor = Color.green;
        line.endColor = Color.green;
    }
    public void BlueColor()
    {
        line.startColor = Color.blue;
        line.endColor = Color.blue;
    }
    public void RedColor()
    {
        line.startColor = Color.red;
        line.endColor = Color.red;
    }
    public void YellowColor()
    {
        line.startColor = Color.yellow;
        line.endColor = Color.yellow;
    }
    public void EraserColor()
    {
        line.startColor = Color.white;
        line.endColor = Color.white;
    }
}