using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 参考：https://qiita.com/ReoNagai/items/928778c0f7e8b8c2dc21

public class AnimalGenerator : MonoBehaviour
{
    private GameObject animalGameObject;
    private SpriteRenderer animalSpriteRenderer;

    private System.Random random = new System.Random();
    private List<string> animalNames = new List<string> {"dog", "monkey", "pheasant"};
    private Vector3 animalInitialGenerationPosition = new Vector3(3, (float)2.5, 0);

    private bool isExistsAnimal = false; // 画面上に動物がいるかどうか
    private bool isDoneReserveGenerationAnimal = false; // 動物を生成する処理が完了しているか

    // Update is called once per frame
    void Update()
    {
        // 動物がいなくて、生成処理を予約していない場合
        if (!isExistsAnimal && !isDoneReserveGenerationAnimal)
        {
            reserveGenerationAnimal();
        }

        // 動物が画面外になったとき、各オブジェクトをリセットする
        if (isExistsAnimal && animalSpriteRenderer == null)
        {
            resetAnimalObj();
        }
    }

    void reserveGenerationAnimal()
    {
        // 2病後にgenerateAnimal()を実施する
        Invoke("generateAnimal", 2);
        isDoneReserveGenerationAnimal = true;
    }

    void generateAnimal()
    {
        var gameObject = getAnimalGameObject();
        animalGameObject = Instantiate(gameObject, animalInitialGenerationPosition, Quaternion.identity, this.transform);
        animalSpriteRenderer = animalGameObject.GetComponent<SpriteRenderer>();

        isExistsAnimal = true;
    }

    GameObject getAnimalGameObject()
    {
        var index = random.Next(0, 3);
        GameObject gameObject = (GameObject)Resources.Load(animalNames[index]);
        return gameObject;
    }

    void resetAnimalObj()
    {
        animalGameObject = null;
        animalSpriteRenderer = null;
        isExistsAnimal = false;
        isDoneReserveGenerationAnimal = false;
    }
}
