

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

	public IJob[] FirstComeFirstServed() {

        //To be implemented by students
        IJob[] A = this.Jobs.ToArray();
        int arrayLength = A.Length;
        // for i <- 0 to n - 2 do
        for (int i = 0; i <= (arrayLength - 2); i++)
        {
            // min <- i
            int min = i;
            // for j <- i + 1 to n - 1 do
            for (int j = (i + 1); j <= (arrayLength - 1); j++)
            {
                //if A[j] < A[min] min <- j
                if (A[j].TimeReceived < A[min].TimeReceived)
                    min = j;
            }
            // swap A[i] and A[min]
            IJob temp = A[min];
            A[min] = A[i];
            A[i] = temp;
        }
        return A;
        //throw new System.NotImplementedException();
    }

    public IJob[] Priority() {

        //To be implemented by students
        IJob[] A = this.Jobs.ToArray();
        int arrayLength = A.Length;
        // for i <- 0 to n - 2 do
        for (int i = 0; i <= (arrayLength - 2); i++)
        {
            // min <- i
            int min = i;
            // for j <- i + 1 to n - 1 do
            for (int j = (i + 1); j <= (arrayLength - 1); j++)
            {
                //if A[j] < A[min] min <- j
                if (A[j].Priority > A[min].Priority)
                    min = j;
            }
            // swap A[i] and A[min]
            IJob temp = A[min];
            A[min] = A[i];
            A[i] = temp;
        }
        return A;

        // throw new System.NotImplementedException();

    }

    public IJob[] ShortestJobFirst() {

        //To be implemented by students
        // Selection Sort
        IJob[] A = this.Jobs.ToArray();
        int arrayLength = A.Length;
        // for i <- 0 to n - 2 do
        for (int i = 0; i <= (arrayLength - 2); i++)
        {
            // min <- i
            int min = i;
            // for j <- i + 1 to n - 1 do
            for (int j = (i + 1); j <= (arrayLength - 1); j++)
            {
                //if A[j] < A[min] min <- j
                if (A[j].ExecutionTime < A[min].ExecutionTime)
                    min = j;
            }
            // swap A[i] and A[min]
            IJob temp = A[min];
            A[min] = A[i];
            A[i] = temp;
        }
        return A;
        // throw new System.NotImplementedException();
    }
}