using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableManager : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject assetReferenceGameObject;
    
   public void AddressablePrefab()
    {

        Addressables.InstantiateAsync(assetReferenceGameObject, new Vector3(-13, -12),Quaternion.identity);
        Addressables.InstantiateAsync(assetReferenceGameObject, new Vector3(23, -38), Quaternion.identity);
    }
}
