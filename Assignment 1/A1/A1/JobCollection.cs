using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	private IJob[] jobs;
	private uint count;

	public JobCollection( uint capacity ) {
		if( !( capacity >= 1 ) ) throw new ArgumentException();
		jobs = new IJob[capacity];
        count = 0;
	}

	public uint Capacity {
		get { return (uint) jobs.Length; }
	}

	public uint Count {
		get { return count; }
	}

	public bool Add( IJob job ) {
        //To be implemented by students
        if (job == null)
        {
            Console.WriteLine("Job has not been added because it is null.\n");
            return false;
        }
        bool jobExists = this.Contains(job.Id);
        if ((count < Capacity) && !jobExists)
        {
            jobs[count] = job;
            count++;
            Console.WriteLine("Job " + job.Id + " has been added! There are " + count + " jobs in the collection.\n");
            return true;
        }
        else if (count >= Capacity)
        {
            Console.WriteLine("The collection is full! Please remove jobs before adding more. \n");
        }
        return false;
        //throw new System.NotImplementedException();
    }

    public bool Contains(uint id) {
        //To be implemented by students
        for (int i = 0; i < count; i++)
            if (jobs[i].Id == id)
            {
                Console.WriteLine("Job " + id + " exists in the collection. ");
                return true;
            }
        Console.WriteLine("Job " + id + " does not currently exist in the collection. ");
        return false;
        //throw new System.NotImplementedException();

    }

    public IJob? Find( uint id ) {
        //To be implemented by students
        for (int i = 0; i < Count; i++)
            if (jobs[i].Id == id)
            {
                Console.WriteLine(jobs[i]);
                return (jobs[i]);
            }
        Console.WriteLine("Job " + id + " does not exist.");
        return null;
        //throw new System.NotImplementedException();

    }

    public bool Remove(uint id) {
        //To be implemented by students
        for (int i = 0; i < count; i++)
            if (jobs[i].Id == id)
            {
                for (int j = i + 1; j < count; j++)
                    jobs[j - 1] = jobs[j];
                Console.WriteLine("Job " + id + " has been removed!");
                count--;
                return true;
            }
        Console.WriteLine("Job " + id + " does not exist in the collection and cannot be removed.");
        return false;
    }

    public IJob[] ToArray() {
        //To be implemented by students
        IJob[] jobArray = new IJob[count];
        for (int i = 0; i < count; i++)
            jobArray[i] = jobs[i];
        return jobArray;

        //throw new System.NotImplementedException();
    }
}
