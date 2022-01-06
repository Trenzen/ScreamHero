using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float bgEndPos;
    public float speed;
    public Vector3 Xstart;
    public Vector3 Xend;
    private void Update()
    {
        if (GameConstants.Activate == true)
        {
            if (GameConstants.Activate == true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                Xend = Camera.main.ScreenToWorldPoint(Vector3.zero);
                Xstart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
                bgEndPos = this.transform.position.x + (this.transform.localScale.x / 2);
                if (bgEndPos < Xend.x)
                {
                    Vector2 pos = new Vector2(Xstart.x + (this.transform.localScale.x / 2) + this.transform.localScale.x, this.transform.position.y);
                    this.transform.position = pos;
                }
            }
        }
    }
}