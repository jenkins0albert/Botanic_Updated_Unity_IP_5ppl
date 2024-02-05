/*
 * Author: Grace Foo
 * Date: 16/1/2024
 * Description: Code movement and navigation of ball!
 */
using UnityEngine;
using UnityEngine.UI;

public class movinggrace : MonoBehaviour 
    //Code was provided by teammate, Grace Foo and I made some tweaks like the speeds and movement
    // to make it optimal for the activity.
{
    // Speed at which the object moves.
    public float moveSpeed = 5f;

    // Button to move the object upwards.
    public Button upButton;

    // Button to move the object downwards.
    public Button downButton;

    // Button to move the object to the left.
    public Button leftButton;

    // Button to move the object to the right.
    public Button rightButton;

    // Start is called before the first frame update
    void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    // Move the object upwards.
    public void MoveUp()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    // Move the object downwards.
    public void MoveDown()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 10);
    }

    // Move the object to the left.
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 10);
    }

    // Move the object to the right.
    public void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Additional update logic can be added here if needed
    }
}
