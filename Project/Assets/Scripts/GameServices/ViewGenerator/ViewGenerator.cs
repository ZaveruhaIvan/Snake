using UnityEngine;

namespace GameServices.ViewGenerator
{
    public class ViewGenerator : IViewGenerator
    {
        public static readonly Vector3 DefaultSpawnPosition = new(10000f, 10000f, 0f);
        
        public T GenerateView<T>(T obj) where T : Object => 
            Object.Instantiate(obj, DefaultSpawnPosition, Quaternion.identity);
        
        public T GenerateView<T>(T obj, Transform parent) where T : Object => 
            Object.Instantiate(obj, DefaultSpawnPosition, Quaternion.identity, parent);

        public GameObject GenerateEmpty(string objectName) => 
            new(objectName);
    }
}