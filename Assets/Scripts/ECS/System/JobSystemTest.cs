using Unity.Entities;
using Unity.Jobs;

public class JobSystemTest : JobComponentSystem{
    AddCounterJob job;

	protected override void OnCreateManager(int capacity)
	{
        base.OnCreateManager(capacity);

        // ジョブ作成
        job = new AddCounterJob();
	}

    // ジョブ発行
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
        return job.Schedule(this, 64, inputDeps);
	}


    [ComputeJobOptimization] // burstコンパイラに最適化
    struct AddCounterJob : IJobProcessComponentData<DataTest>{
        public void Execute(ref DataTest data){
            data.count++;
        }
    }
}
