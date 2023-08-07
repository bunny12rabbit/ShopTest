using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Core.Common
{
    public abstract class InitializableMonoBehaviour<TInputParams> : MonoBehaviour, IInitializableMonoBehaviour<TInputParams>
    {
        private readonly CompositeDisposable _disposables = new();
        public ICollection<IDisposable> Disposables => _disposables;

        private readonly ReactiveProperty<bool> _isInitialized = new();
        public IReadOnlyReactiveProperty<bool> IsInitialized => _isInitialized;

        private Action _onDispose;

        Action ICustomDisposable.OnDispose
        {
            get => _onDispose;
            set => _onDispose = value;
        }

        protected TInputParams InputParams { get; private set; }

        protected virtual void Awake()
        {
            if (!_isInitialized.Value)
                enabled = false; // Чтобы не добавлять в каждом наследнике проверки на инициализацию в Update/FixedUpdate.
        }

        public IDisposable Init(TInputParams inputParams)
        {
            InputParams = inputParams;
            enabled = true;
            Init();
            _isInitialized.Value = true;

            return this;
        }

        public virtual void Dispose()
        {
            _disposables.Clear();
            InputParams = default;
            _isInitialized.Value = false;
            enabled = false;
            _onDispose?.Invoke();
            _onDispose = null;
        }

        protected virtual void Init()
        {
        }
    }
}