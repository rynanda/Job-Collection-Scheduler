class Program
{
    static void Main(string[] args)
    {
        // New instances of JobCollection and Scheduler
        JobCollection aCollection = new JobCollection(10);
        Scheduler scheduler = new(aCollection);

        // Create new jobs
        IJob job = new Job(523, 90, 23, 8);
        IJob job2 = new Job(966, 46, 15, 2);
        IJob job3 = new Job(26, 11, 50, 5);
        IJob job4 = new Job(553, 35, 12, 1);
        IJob job5 = new Job(346, 79, 6, 5);
        IJob job6 = new Job(560, 95, 47, 2);
        IJob job7 = new Job(132, 13, 18, 8);
        IJob job8 = new Job(741, 92, 37, 9);
        IJob job9 = new Job(267, 11, 50, 5);
        IJob job10 = new Job(583, 97, 22, 2);

        // Test 1: Add new jobs to the JobCollection instance with the 'Add' and 'ToArray' methods.
        Console.WriteLine("Test 1: Add new jobs to the JobCollection instance with the 'Add' and 'ToArray' methods.\n");
        /* This test ensures that the Add method is implemented correctly. */
        
        // Display current count and capacity of jobs in the collection.
        Console.WriteLine("Number of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity+ "\n");

        // Populate JobCollection with new jobs
        aCollection.Add(job);
        aCollection.Add(job2);
        aCollection.Add(job3);
        aCollection.Add(job4); 
        aCollection.Add(job5);
        aCollection.Add(job6);
        aCollection.Add(job7);
        aCollection.Add(job8);
        aCollection.Add(job9);
        aCollection.Add(job10);

        // Convert JobCollection into an IJob array called 'jobs' using the ToArray method
        IJob[] jobs = aCollection.ToArray();

        // Print jobs array to console and check if all jobs are added correctly.
        Console.WriteLine("Input data:");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");
        /* The two lines above will be reused as a printArray helper method below that
         which will take IJob[] for the purpose of applying selection sort algorithms
         based on specific fields within the jobs array to create sorted arrays. */

        Console.WriteLine("---------------------------------------------------------");

        // Test 2: First Come First Served Sort
        Console.WriteLine("Test 2: First Come First Served Sort\n");
        /* In this test, aCollection will be sorted based on the First Come First Served
         selection sort algorithm. In this algorithm, a given collection is sorted by
         increasing order of the 'timeReceived' field. */
        
        // Apply algorithm to collection and assign to new IJob array.
        IJob[] firstComeFirstServedSort = scheduler.FirstComeFirstServed();

        // Print the sorted array to the console and check if it functions as intended.
        Console.WriteLine("Schedule by First Come First Served:");
        printArray(firstComeFirstServedSort);
        Console.WriteLine("---------------------------------------------------------");

        // Test 3: Shortest Job First Sort
        Console.WriteLine("Test 3: Shortest Job First Sort\n");
        /* In this test, aCollection will be sorted based on the Shortest Job First
         selection sort algorithm. In this algorithm, a given collection is sorted by
         increasing order of the 'executionTime' field. */

        // Apply algorithm to collection and assign to new IJob array.
        IJob[] shortestSort = scheduler.ShortestJobFirst();

        // Print sorted array to the console.
        Console.WriteLine("Schedule by Shortest Job First:");
        printArray(shortestSort);
        Console.WriteLine("---------------------------------------------------------");

        // Test 4: Priority Sort
        Console.WriteLine("Test 4: Priority Sort\n");
        /* In this test, aCollection will be sorted based on the Priority selection sort algorithm. 
         * In this algorithm, a given collection is sorted by increasing order of the 
         * 'priority' field. */

        // Apply algorithm to collection and assign to new IJob array.
        IJob[] prioritySort = scheduler.Priority();

        // Print sorted array to the console.
        Console.WriteLine("Schedule by Priority:");
        printArray(prioritySort);
        Console.WriteLine("---------------------------------------------------------");

        // Test 5: Remove jobs from the collection using 'Remove' method.
        Console.WriteLine("Test 5: Remove jobs from the collection using 'Remove' method.\n");
        // This test ensures the Remove method is implemented correctly.

        // Display current collection.
        Console.WriteLine("Current collection:");
        printArray(jobs);
        Console.WriteLine();

        /* Remove jobs from the collection based on job ID and assign new collection to jobs. 
         In this test case, five of the existing ten jobs will be removed. */
        aCollection.Remove(267);
        aCollection.Remove(966);
        aCollection.Remove(560);
        aCollection.Remove(741);
        aCollection.Remove(583);
        jobs = aCollection.ToArray();

        // Print new jobs array to console. Check if corresponding jobs are removed.
        Console.WriteLine("\nNew collection:");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity);

        Console.WriteLine("---------------------------------------------------------");

        // Test 6: Removing a job that does not exist in the collection.
        Console.WriteLine("Test 6: Removing a job that does not exist in the collection.\n");
        /* Ensures no jobs are removed and count and capacity stay the same after 
        / trying to remove a job that does not exist. */

        aCollection.Remove(999);
        aCollection.Remove(519);
        aCollection.Remove(44);

        // Print jobs array to console. Collection, count, and capacity should all remain the same.
        Console.WriteLine("\nCollection, count, and capacity stay the same:");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 7: Functionality of 'Contains' method.
        Console.WriteLine("Test 7: Functionality of 'Contains' method.\n");
        // Ensures the Contains method is implemented correctly.

        // Test if the method returns true if we pass job IDs we know exists in the job collection.
        Console.WriteLine("Check if collection contains jobs we know exists (with ID):");
        aCollection.Contains(346);
        aCollection.Contains(26);
        aCollection.Contains(132);

        // Test if the method returns false if we pass job IDs we know do not exist in the job collection.
        Console.WriteLine("\nCheck if collection contains jobs we know do not exist:");
        aCollection.Contains(999);
        aCollection.Contains(92);
        aCollection.Contains(672);

        Console.WriteLine("\nThe data remains unchanged:");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 8: Find a job in the collection based on their job ID using the 'Find' method.
        Console.WriteLine("Test 8: Find a job in the collection based on their job ID using the 'Find' method.\n");
        // Ensures the Find method works as intended.

        // Find jobs that we know exist.
        Console.WriteLine("Find and display jobs with IDs that exist in the collection:");
        aCollection.Find(26);
        aCollection.Find(346);
        aCollection.Find(132);

        // Find jobs that we know do not exist (to check if the null post-condition works).
        Console.WriteLine("\nFind and display jobs with IDs that do not exist in the collection:");

        aCollection.Find(999);
        aCollection.Find(888);

        Console.WriteLine("\nThe data remains unchanged:");
        for (int i = 0; i < jobs.Length; i++)
            Console.WriteLine(jobs[i]);
        Console.WriteLine();
        Console.WriteLine("Number of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 9: Adding a job that already exists.
        Console.WriteLine("Test 9: Adding a job that already exists.\n");

        IJob job11 = new Job(26, 58, 23, 3);
        IJob job12 = new Job(346, 32, 69, 7);
        IJob job13 = new Job(132, 40, 14, 9);
        aCollection.Add(job11);
        aCollection.Add(job12);
        aCollection.Add(job13);
        jobs = aCollection.ToArray();

        Console.WriteLine();
        Console.WriteLine("Collection remains unchanged: ");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 10: Add a job that is null.
        Console.WriteLine("Test 10: Adding a job that is not null.\n");

        IJob job14 = null;
        aCollection.Add(job14);
        Console.WriteLine("Collection remains unchanged: ");
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 11: Going above capacity of the collection.
        Console.WriteLine("Test 11: Going above capacity of the collection.\n");
        IJob job15 = new Job(235, 46, 19, 7);
        IJob job16 = new Job(621, 36, 16, 3);
        IJob job17 = new Job(153, 15, 6, 5);
        IJob job18 = new Job(649, 34, 23, 8);
        IJob job19 = new Job(953, 12, 34, 9);
        IJob job20 = new Job(12, 7, 8, 2);
        IJob job21 = new Job(219, 17, 6, 4);
        IJob job22 = new Job(21, 46, 35, 6);
        aCollection.Add(job15); 
        aCollection.Add(job16); 
        aCollection.Add(job17);
        aCollection.Add(job18);
        aCollection.Add(job19); 
        aCollection.Add(job20);
        aCollection.Add(job21);
        aCollection.Add(job22);

        jobs = aCollection.ToArray();
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");

        Console.WriteLine("---------------------------------------------------------");

        // Test 12: Job edge case and exception tests.
        Console.WriteLine("Test 12: Job edge case tests.\n");

        aCollection.Remove(553);
        aCollection.Remove(132);
        aCollection.Remove(621);
        aCollection.Remove(26);
        aCollection.Remove(235);

        Console.WriteLine();

        IJob job23 = new Job(1, 1, 1, 1);
        IJob job24 = new Job(999, 999, 999, 9);
        //IJob job25 = new Job(1000, 46, 21, 6); // ArgumentOutOfRangeException
        //IJob job26 = new Job(0, 64, 23, 1); // ArgumentOutOfRangeException
        //IJob job27 = new Job(1, 0, 1, 1); // ArgumentOutOfRangeException
        //IJob job28 = new Job(1, 1, 0, 1); // ArgumentOutOfRangeException


        aCollection.Add(job23); 
        aCollection.Add(job24);
        //aCollection.Add(job25); 
        //aCollection.Add(job26);
        //aCollection.Add(job27);
        //aCollection.Add(job28);

        jobs = aCollection.ToArray();
        printArray(jobs);
        Console.WriteLine("\nNumber of jobs in the collection: " + aCollection.Count);
        Console.WriteLine("Capacity of collection: " + aCollection.Capacity + "\n");
    }
    static void printArray(IJob[] A)
    {
        for (int i = 0; i < A.Length; i++)
            Console.WriteLine(A[i]);
    }
}