using Tolian.Runtime.Systems.ObjectPoolDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Interfaces
{
    public interface IProvideObject
    {
        GameObject GetObjectFromObjectPool(ObjectPoolType targetObjectPoolType);
        GameObject GetObjectFromPrefab(GameObject targetPrefab);
    } 
}

