using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movinggrace : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Button upButton, downButton, leftButton, rightButton;
    // Start is called before the first frame update
    void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }
    public void MoveUp()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 10);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 10);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
