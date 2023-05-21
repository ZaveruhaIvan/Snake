using System.Collections.Generic;
using GameServices.ViewGenerator;
using UnityEngine;

namespace GameServices.ViewPool
{
    public class ViewPool<T> where T : MonoBehaviour, IPooledRelease
    {
        private readonly IViewGenerator _viewGenerator;
        private readonly T _asset;
        private readonly Queue<T> _queue;
        private readonly Transform _parent;

        public ViewPool(int poolAmount, T asset, IViewGenerator viewGenerator)
        {
            _asset = asset;
            _viewGenerator = viewGenerator;
            _queue = new Queue<T>(poolAmount);
            _parent = _viewGenerator.GenerateEmpty($"{typeof(T).Name}_pool").transform;
            Object.DontDestroyOnLoad(_parent);
            
            for (var i = 0; i < poolAmount; i++)
            {
                _queue.Enqueue(GenerateNewView());
            }
        }

        public T GetView() => 
            _queue.Count > 0 ? _queue.Dequeue() : GenerateNewView();

        public void Release(T obj)
        {
            obj.transform.parent = _parent;
            obj.Release();
            _queue.Enqueue(obj);
        }
        
        private T GenerateNewView() => 
            _viewGenerator.GenerateView(_asset, _parent);
    }
}