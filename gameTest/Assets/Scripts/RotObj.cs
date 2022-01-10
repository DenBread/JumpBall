using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotObj : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Move>())
        {
            collision.transform.GetComponent<Move>().isGround = true;
            //Quaternion q = new Quaternion(0,0,90,0);
            //collision.transform.Rotate(0,0,180);
            //Vector3 direction = collision.gameObject.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(direction, Vector3.right);

            Vector3 vec = collision.gameObject.transform.position - gameObject.transform.position;
            Quaternion q = Quaternion.LookRotation(vec, Vector3.forward);
            q = new Quaternion(0,0,q.z, q.w);
            //Debug.Log(q.eulerAngles);
            collision.transform.rotation = q;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            collision.transform.SetParent(gameObject.transform); // Устанавливаем родилеля

            if (gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<ColorPoint>().yellow)
            {
                collision.gameObject.GetComponent<ColorPoint>().SwitchingColors(Color.yellow, true);
                collision.gameObject.GetComponent<Score>().AddScore();
                GameObject gm = Instantiate(collision.gameObject.GetComponent<EffectBoom>().effectBoom, gameObject.transform);
                Destroy(gm, 1f);

            }
            if(gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<ColorPoint>().yellowGray)
            {
                speed = -speed;
            }

        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Move>())
        {
            //Debug.Log("Вышел");
            collision.transform.parent = null;
            collision.transform.GetComponent<Move>().isGround = false;
        }
    }
}
