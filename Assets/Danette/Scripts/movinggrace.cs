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

    public Rigidbody rg;
    
    // Start is called before the first frame update
    void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    // Move the object upwards.
   

    // Move the object downwards.
    public void MoveUp()
    {
        Move(Vector3.forward);
    }

    public void MoveDown()
    {
        Move(Vector3.back);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }

    public void MoveRight()
    {
        Move(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        // Additional update logic can be added here if needed
    }

    void Move(Vector3 direction)
    {
        Vector3 movement = direction * Time.deltaTime * moveSpeed;
        rg.MovePosition(transform.position + movement);
    }
}
