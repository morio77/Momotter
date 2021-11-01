using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Rigidbody2D animalRigidbody2D;
    private SpriteRenderer animalSpriteRenderer;

    private float animalSpeed = 2;
    private float addAnimalSpeed = 2;

    private bool isPressRightArrow = false;

    // Start is called before the first frame update
    void Start()
    {
        animalRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animalSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 動物が画面外になったとき、各オブジェクトをリセットする
        if (animalSpriteRenderer != null && !animalSpriteRenderer.isVisible)
        {
            deleteAnimal();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isPressRightArrow = true;
        }
    }

    // 団子にあたったら、各オブジェクトをリセットする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "dango")
        {
            deleteAnimal();
        }
    }

    private void FixedUpdate()
    {
        float speed;
        // スペースキーが押されている間は、さらに左に動かす
        if (isPressRightArrow)
        {
            speed = animalSpeed + addAnimalSpeed;
            isPressRightArrow = false;
        }
        else
        {
            speed = animalSpeed;
        }

        // 動物を左に動かしていく
        animalRigidbody2D?.MovePosition(new Vector2(animalRigidbody2D.position.x + speed * (-1) * Time.fixedDeltaTime, animalRigidbody2D.position.y));
    }

    void deleteAnimal()
    {
        Destroy(this.gameObject);
        animalRigidbody2D = null;
        animalSpriteRenderer = null;
    }
}
