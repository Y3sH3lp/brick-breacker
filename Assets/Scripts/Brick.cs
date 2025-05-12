using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isUnbreakable = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isUnbreakable)
            {
                GameManager.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }
    }
}
