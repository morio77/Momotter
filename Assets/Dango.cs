using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dango : MonoBehaviour
{
    [SerializeField] private SpriteRenderer dangoRenderer;
    private Rigidbody2D dangoRigidbody2D;
    private Vector2 initialDangoPosition = new Vector2((float)-2.15, (float)-2.46);
    private Vector2 dangoLaunchForce = new Vector2(0, 4);

    private bool isLaunchedDango = false;

    // Start is called before the first frame update
    void Start()
    {
        dangoRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押したら団子を上に発射
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunchedDango)
        {
            isLaunchedDango = true;
            dangoRigidbody2D.AddForce(dangoLaunchForce, mode: ForceMode2D.Impulse);
        }

        // 団子が画面外に出たら、初期値に戻す
        if (!dangoRenderer.isVisible)
        {
            initializeDango();
        }
    }

    // 動物にあたったら、各オブジェクトをリセットする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "dog(Clone)" ||
            collision.gameObject.name == "monkey(Clone)" ||
            collision.gameObject.name == "pheasant(Clone)")
        {
            initializeDango();
        }
    }

    // 団子を初期値に戻して、非表示にするメソッド
    private void initializeDango()
    {
        isLaunchedDango = false;
        dangoRigidbody2D.velocity = new Vector2(0, 0);
        dangoRigidbody2D.position = initialDangoPosition;
    }
}
