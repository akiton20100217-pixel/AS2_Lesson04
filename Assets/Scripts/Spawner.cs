using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public class Spawner : MonoBehaviour
{
    //クラスでやること = プレハブを生成する
    //spaen()メソッドを呼び出すのみ

    private GameObject[] _prefabs; //生成するプレハブの参照

    public bool _isLoaded = false; //ロード完了フラグ

    public async void LoadAsync( string label ) //非同期型アセット読み込みメソッド
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>( label );
        IList<GameObject> result = await handle.ToUniTask();
        //awaitより後は読み込みが終わっている

        _prefabs = result.ToArray();
        _isLoaded = true;
    }

    /*
    public void Spawn(int index)
    {
        //オブジェクトを設定しプレハブを生成する
        if (_isLoaded)
        {
            GameObject.Instantiate(_prefabs[index]);
            Debug.Log($"Spawned: {_prefabs[index].name}");
        }
        else
        {
            Debug.Log("Prefab is not loaded yet.");
        }
    } 
    */
    public void Spawn(string name)
    {
        //配列全てから名前検索で取得しプレハブを生成する
        if (_isLoaded)
        {
            for (int i = 0; i < _prefabs.Length; i++)
            {
                if (_prefabs[i].name == name)
                {
                    GameObject.Instantiate(_prefabs[i]);
                    Debug.Log($"Spawned: {_prefabs[i].name}");
                    return;
                }
            }

            Debug.Log($"Prefab with name '{name}' not found.");
        }
        else
        {
            Debug.Log("Prefab is not loaded yet.");
        }

    }
}