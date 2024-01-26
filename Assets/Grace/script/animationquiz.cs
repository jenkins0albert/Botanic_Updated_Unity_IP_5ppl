/*
 * Author: Grace Foo
 * Date: 24/1/2024
 * Description: Code for playing animations for the quiz game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationquiz : MonoBehaviour
{
    public Animator duck;
    public Animator monkey;
    public Animator swan;
    public void swanAnimation()
    {
        swan.SetTrigger("moveswan");
    }
    public void monkeyAnimation()
    {
        monkey.SetTrigger("movemonkey");
    }
    public void duckAnimation()
    {
        duck.SetTrigger("moveduck");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
