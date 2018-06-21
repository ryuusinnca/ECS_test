using UnityEngine;
using Unity.Entities;
using Unity.Collections;

public class EntityTest : MonoBehaviour{
    [SerializeField] int _count = 10000;
    [SerializeField] RangeData range;

	void Start(){
        // managerの生成
        var em = World.Active.GetOrCreateManager<EntityManager>();
        // アーキタイプの定義
        var archetype = em.CreateArchetype(typeof(DataTest),typeof(RangeData));
        // アーキタイプをもとにentityを生成

        World.Active.GetExistingManager<SystemTest>().Enabled = false;
        //World.Active.GetExistingManager<JobSystemTest>().Enabled = false;

        for (int i = 0; i < _count; ++i)
        {
            var en = em.CreateEntity(archetype);
            em.SetSharedComponentData<RangeData>(en, range);
        }

	}
}