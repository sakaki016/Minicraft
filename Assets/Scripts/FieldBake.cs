using System;
using System.Threading;
using System.Threading.Tasks;
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
    }

    void Update()
    {
        _ = DelayAsync(destroyCancellationToken);

    }

    private async ValueTask DelayAsync(CancellationToken token)
    {
        // X秒間待つ
        await Task.Delay(TimeSpan.FromSeconds(delay), token);

        //Bakeする
        Build();
    }

    public void Build()
    {
        surface.BuildNavMesh();
    }
}




