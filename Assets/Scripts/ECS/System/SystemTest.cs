using Unity.Entities;

public class SystemTest : ComponentSystem {
    struct Group{
        // Lengthにデータ数が自動で格納される模様
        public int Length;
        public ComponentDataArray<DataTest> dataTest;
    }
    [Inject] Group _group;
    protected override void OnUpdate () {
        for (int i = 0; i < _group.Length;++i){
            var data = _group.dataTest[i];
            data.count++;
            _group.dataTest[i] = data;
        }
	}
}