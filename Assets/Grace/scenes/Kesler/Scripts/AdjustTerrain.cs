using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdjustTerrain : MonoBehaviour
{   
    public Slider ScaleSlider;
    //public Slider RotateSlider;

    //public float rotationMin = 0.0f;
    //public float rotationMax = 45.0f;
    //[SerializeField] float currentRotation = 0f;
    
    [SerializeField] float currentScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ScaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();

        currentScale = 0.2f;
        transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
    }

    // Update is called once per frame
    void Update()
    {   
        //transform.localEulerAngles = new Vector3(0.0f)
        transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
        Debug.Log("Current Scale: " + transform.localScale);
    }

    private void OnGUI()
    {
        //currentRotation = GUI.HorizontalSlider(new Rect(-280.0f, 165.0f, 228.0f, 57.0f), currentRotation, 0.0f, 45.0f);
        //transform.localEulerAngles = new Vector3(0.0f, currentRotation, 0.0f);
        currentScale = GUI.HorizontalSlider(new Rect(-280.0f, 120.0f, 228.0f, 57.0f), currentScale, 0.0f, 2.0f);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    public void AdjustScale(float newScale)
    {

    }
}   
