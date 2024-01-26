using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdjustTerrain : MonoBehaviour
{   
    public float rotationMin = 0f;
    public float rotationMax = 360.0f;

    public Slider RotateSlider;
    public Slider ScaleSlider;

    [SerializeField] float currentRotation = 0.0f;
    [SerializeField] float currentScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        RotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        ScaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();

        transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.localEulerAngles = new Vector3(0.0f, RotateSlider.value, 0.0f);
        transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
    }

    private void OnGUI()
    {
        currentRotation = GUI.HorizontalSlider(new Rect(-280.0f, 165.0f, 228.0f, 57.0f), currentRotation, 0.0f, 45.0f);
        transform.localEulerAngles = new Vector3(0.0f, currentRotation, 0.0f);
        currentRotation = GUI.HorizontalSlider(new Rect(-280.0f, 120.0f, 228.0f, 57.0f), currentScale, 0.0f, 2.0f);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    public void AdjustAngle(float newAngle)
    {

    }

    public void AdjustScale(float newScale)
    {

    }
}   
