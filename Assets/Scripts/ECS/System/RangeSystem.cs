using Unity.Entities;
using Unity.Collections;

[UpdateAfter(typeof(SystemTest))]
public class RangeSystem : ComponentSystem{
    struct Group
    {
        // Lengthにデータ数が自動で格納される模様
        public int Length;
        public EntityArray entities;
        [ReadOnly] public ComponentDataArray<DataTest> dataTest;
        [ReadOnly] public SharedComponentDataArray<RangeData> rangeData;
    }
    [Inject] Group _group;
    protected override void OnUpdate(){
        for (int i = 0; i < _group.Length; ++i){
            var range = _group.rangeData[i];
            var data = _group.dataTest[i];
            if(data.count > range.max || data.count < range.min){
                PostUpdateCommands.DestroyEntity(_group.entities[i]);
            }
        }
    }
}
