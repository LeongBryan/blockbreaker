using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    internal float horizontal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "paddle1")
        {
            horizontal = Input.GetAxis("Horizontal");

            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

            if (transform.position.x < leftScreenEdge)
            {
                transform.position = new Vector2(rightScreenEdge, transform.position.y);
            };

            if (transform.position.x > rightScreenEdge)
            {
                transform.position = new Vector2(leftScreenEdge, transform.position.y);
            };
        }
        if (transform.tag == "paddle2")
        {
            horizontal = Input.GetAxis("Horizontal2");

            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

            if (transform.position.x < leftScreenEdge)
            {
                transform.position = new Vector2(rightScreenEdge, transform.position.y);
            };

            if (transform.position.x > rightScreenEdge)
            {
                transform.position = new Vector2(leftScreenEdge, transform.position.y);
            };

        }

    }
}
