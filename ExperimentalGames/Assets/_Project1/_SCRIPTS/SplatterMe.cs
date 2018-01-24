using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterMe : MonoBehaviour {

    private Transform projectile;
    public int player_num;
    public GameObject groundSplatter;

    private void Start()
    {
        projectile = this.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("splatterMe"))
        {
            projectile.gameObject.SetActive(false);
            GameObject clone = Instantiate(groundSplatter, projectile.position, Quaternion.identity) as GameObject;

            //blue
            if (player_num == 1)
            {
                clone.GetComponent<SpriteRenderer>().color = new Color32(66, 93, 140, 255);
            }
            //red
            else
            {
                clone.GetComponent<SpriteRenderer>().color = new Color32(137, 46, 47, 255);
            }
        }
    }
}
