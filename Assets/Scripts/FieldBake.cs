using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

public class FieldBake : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    [SerializeField] int delay;


    //NavMeshSurfaceをワールド生成直後にビルド
    void Start()
    {
        Build();
        Debug.Log("初期ビルド");
        UpdateLoop(this.GetCancellationTokenOnDestroy()).Forget();
    }

    async UniTaskVoid UpdateLoop(CancellationToken ct = default)
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: ct);
            Build();
        }
    }

    public void Build()
    {
        surface.BuildNavMesh();
        Debug.Log("再ビルド");
    }

}




