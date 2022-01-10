using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool keySpace;
    public bool isGame;
    public bool isGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        keySpace = Input.GetKeyDown(KeyCode.Space);
        //target.transform.RotateAround(target.transform.position, Vector3.forward, 20*Time.deltaTime);

        /// рисуем в player mode линию
        Quaternion rotation = Quaternion.AngleAxis(45, gameObject.transform.right);
        Debug.DrawRay(transform.position, rotation * transform.forward * 3f, Color.red);
        ///


        if (Input.GetMouseButtonDown(0) && isGround && isGame)
        {
            Ray2D ray2D = In;

            Debug.Log("Тачит");
            keySpace = true;
        }
        else
        {
            keySpace = false;
        }
    }

    private void FixedUpdate()
    {
        if (keySpace)
        {
            rb.AddRelativeForce(Vector2.down * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public void Gameplay(bool isGame)
    {
        this.isGame = isGame;
    }

}
