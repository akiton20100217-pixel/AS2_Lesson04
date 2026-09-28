using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SampleTask : MonoBehaviour
{
    //async:そのメソッドを分離させる
    //await:処理を待たせる
    //UniTask.WaitForSeconds(float):float秒待つ

    private async void Start()
    {
        /*
        for (int i = 0; i < 1000; i++)
        {
            await UniTask.WaitForSeconds(0.5f);
            Debug.Log("Start");
        }
        */

        //Addressableのアセット読み込み処理
        //================================================================-
        var hanndle = Addressables.LoadAssetAsync<GameObject>("Prefabs");
        GameObject Prefab = await hanndle.ToUniTask();

        Debug.Log($"読み込み済み => {Prefab.name}");
        Instantiate(Prefab);
        //================================================================-


        //上の複数バージョン
        //=================================================================
        var handles = Addressables.LoadAssetsAsync<GameObject>("Prefabs");
        IList<GameObject> prefabs = await handles.ToUniTask();

        for(int i = 0; i < prefabs.Count; i++)
        {
            Debug.Log($"読み込み済み => {prefabs[i].name}");
            Instantiate(prefabs[i]);
        }
        //=================================================================
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}
