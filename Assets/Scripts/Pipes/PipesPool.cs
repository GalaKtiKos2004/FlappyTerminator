using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PipesPool : MonoBehaviour
{
    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _poolMaxSize;

    private List<Pipe> _createdPipes;

    private ObjectPool<Pipe> _pipes;

    private void Awake()
    {
        _createdPipes = new List<Pipe>();

        _pipes = new ObjectPool<Pipe>(
            createFunc: () => CreatePipe(),
            actionOnGet: pipe => pipe.gameObject.SetActive(true),
            actionOnRelease: pipe => pipe.gameObject.SetActive(false),
            actionOnDestroy: pipe => Destroy(pipe.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolMaxSize,
            maxSize: _poolMaxSize);
    }

    public Pipe GetPipe() => _pipes.Get();

    public void ReleasePipe(Pipe pipe)
    {
        _pipes.Release(pipe);
    }

    public void Clear()
    {
        foreach (Pipe pipe in _createdPipes)
        {
            Destroy(pipe.gameObject);
        }

        _pipes.Clear();
        _createdPipes.Clear();
    }

    private Pipe CreatePipe()
    {
        Pipe pipe = Instantiate(_prefab);
        _createdPipes.Add(pipe);

        return pipe;
    }
}
