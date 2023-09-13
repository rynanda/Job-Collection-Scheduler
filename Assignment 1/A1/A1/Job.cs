using System;


public class Job : IJob {
	public Job( uint jobId, uint timeReceived, uint executionTime, uint priority ) {
		Id = jobId;
		TimeReceived = timeReceived;
		ExecutionTime = executionTime;
		Priority = priority;
	}

	private uint id;
	private uint timeReceived;
	private uint executionTime;
	private uint priority;

	public uint Id {
        get
        {
			return id;
		}
		private set {
			if (!IsValidId( value ))
				throw new ArgumentOutOfRangeException( nameof( Id ) );
			id = value;
		}
	}

	public uint TimeReceived {
		get {
			return timeReceived;
		}
		private set {
            if (!IsTimeReceived(value))
                throw new ArgumentOutOfRangeException(nameof(Id));
            timeReceived = value;
		}
	}

	public uint ExecutionTime {
		get {
			return executionTime;
		}
		private set {
			if (!IsValidExecutionTime( value ))
				throw new ArgumentOutOfRangeException( nameof( ExecutionTime ) );
			executionTime = value;
		}
	}

	public uint Priority {
		get {
			return priority;
		}
		private set {
			if (!IsValidPriority( value ))
				throw new ArgumentException( nameof( Priority ) );
			priority = value;
		}
	}

	public static bool IsValidId( uint id ) {

		//To be implemented by students
		if ((1 <= id) && (id <= 999))
			return true;
		else
			return false;
		//throw new System.NotImplementedException();

    }

	public static bool IsValidExecutionTime( uint executiontime ) {

		//To be implemented by students
		if (executiontime > 0)
			return true;
		else
			return false;
        //throw new System.NotImplementedException();

    }

    public static bool IsValidPriority( uint priority ) {

		//To be implemented by students
		if ((1 <= priority) && (priority <= 9))
			return true;
		else
			return false;
        //throw new System.NotImplementedException();

    }

    public static bool IsTimeReceived(uint time) {

        //To be implemented by students
		if (time > 0)
			return true;
		else
			return false;
        //throw new System.NotImplementedException();

    }

    public override string ToString() {
		return $"Job(jobId: {id}, timeReceived: {timeReceived}, executionTime: {executionTime}, priority: {priority})";
	}
}
