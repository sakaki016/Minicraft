using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

public class FieldBake : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    [SerializeField] int delay;


    /// <summary>
    /// NavMeshSurfaceをワールド生成直後にビルド
    /// </summary>
    void Start()
    {
        Build();
        UpdateLoopAsync(this.GetCancellationTokenOnDestroy()).Forget();
    }

    /// <summary>
    /// 遅延処理
    /// </summary>
    async UniTaskVoid UpdateLoopAsync(CancellationToken ct = default)
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: ct);
            Build();
        }
    }

    /// <summary>
    /// マップのNavMeshを更新
    /// </summary>
    public void Build()
    {
        surface.BuildNavMesh();
        Debug.Log("ビルド");
    }

}




