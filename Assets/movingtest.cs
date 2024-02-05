using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movingtest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Button upButton, downButton, leftButton, rightButton;

    void Start()
    {
        // Add click listeners to the UI buttons
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    void MoveUp()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
