using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 参考：https://futabazemi.net/notes/unity-tatescroll/

public class ScreenScroll : MonoBehaviour
{
    public float playerSpeed = 1; // スクロールスピード
    private readonly float leftEnd = (float)-5.6; // 画像の中心がこのx座標よりも左にいくと、右に移動させる
    private readonly float rightEnd = (float)5.6; // 画像を右に移動させるときの中心のx座標

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右キーを押すと、背景が左に動く
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var deltaPosition = new Vector3(-playerSpeed * Time.deltaTime, 0);
            transform.position += deltaPosition;
        }

        // 画像x:-0.02よりも左にいったとき、x:11.24に移動する
        if (transform.position.x <= leftEnd)
        {
            transform.position = new Vector3(rightEnd, transform.position.y);
        }
    }

}
