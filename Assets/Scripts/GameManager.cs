using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲーム全体管理クラス

    private Spawner _spawner;
    
    void Start()
    {
        _spawner = new Spawner();//オブジェクト生成クラスのインスタンス化
        _spawner.LoadAsync("Prefabs");//非同期でPrefabをロード
    }

    void Update()
    {
        string name = "Cube";//生成するPrefabの名前を指定
        //int index = Random.Range(0, 3);//0~2のランダムな整数を生成
        _spawner.Spawn(name);//毎フレームPrefabを生成
    }
}
