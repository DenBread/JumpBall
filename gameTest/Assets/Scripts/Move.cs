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

    // ReSharper disable Unity.PerformanceAnalysis
    private void Update()
    {
        keySpace = Input.GetKeyDown(KeyCode.Space);
        //target.transform.RotateAround(target.transform.position, Vector3.forward, 20*Time.deltaTime);

        /// ������ � player mode �����
        Quaternion rotation = Quaternion.AngleAxis(45, gameObject.transform.right);
        Debug.DrawRay(transform.position, rotation * transform.forward * 3f, Color.red);
        ///


        if (Input.GetMouseButtonDown(0) && isGround && isGame)
        {
            Debug.Log("�����");
            keySpace = true;
        }
        else
        {
            keySpace = false;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
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
