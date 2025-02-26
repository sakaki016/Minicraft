using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

public class FieldBake : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    [SerializeField] int delay;


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
        // X•bŠÔ‘Ò‚Â
        await Task.Delay(TimeSpan.FromSeconds(delay), token);

        //Bake‚·‚é
        Build();
    }


    public void Build()
    {
        surface.BuildNavMesh();
    }
}




