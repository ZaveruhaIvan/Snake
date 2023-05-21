using UnityEngine;

namespace GameServices.ViewGenerator
{
    public interface IViewGenerator
    {
        T GenerateView<T>(T obj) where T : Object;
        T GenerateView<T>(T obj, Transform parent) where T : Object;
        GameObject GenerateEmpty(string objectName);
    }
}