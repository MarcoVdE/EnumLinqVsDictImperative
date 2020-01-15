using System;
using System.Diagnostics;

namespace EnumLinqVsDictImperative
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayTimerProperties();

            Console.WriteLine();
            Console.WriteLine("Press the Enter key to begin:");
            Console.ReadLine();
            Console.WriteLine();

            TimeOperationsLinqAsParallel();
            TimeOperationsDict();
            TimeOperationsLinq();
        }

        public static void DisplayTimerProperties()
        {
            // Display the timer frequency and resolution.
            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
            }
            else 
            {
                Console.WriteLine("Operations timed using the DateTime class.");
            }

            long frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}",
                frequency);
            long nanosecPerTick = (1000L*1000L*1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds", 
                nanosecPerTick);
        }
        
        private static void TimeOperationsLinq()
        {
            long nanosecPerTick = (1000L*1000L*1000L) / Stopwatch.Frequency;
            const long numIterations = 10000;

            // Define the operation title names.
            String [] operationNames = {"Operation: TimeOperationsLinq(\"0\")",
                                           "Operation: TimeOperationsLinq(\"0\")",
                                           "Operation: TimeOperationsLinq(\"a\")",
                                           "Operation: TimeOperationsLinq(\"a\")"};

            // Time four different implementations for parsing 
            // an integer from a string. 

            for (int operation = 0; operation <= 3; operation++)
            {
                // Define variables for operation statistics.
                long numTicks = 0;
                long numRollovers = 0;
                long maxTicks = 0;
                long minTicks = Int64.MaxValue;
                int indexFastest = -1;
                int indexSlowest = -1;
                long milliSec = 0;

                Stopwatch time10kOperations = Stopwatch.StartNew();

                // Run the current operation 10001 times.
                // The first execution time will be tossed
                // out, since it can skew the average time.

                var myenum = new EnumTest();
                
                for (int i=0; i<=numIterations; i++) 
                {
                    long ticksThisTime = 0;
                    int inputNum;
                    Stopwatch timePerParse;

                    switch (operation)
                    {
                        case 0:
                            // Parse a valid integer using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            //run Enums test:
                            
                            myenum.incrementEnum();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.

                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 1:
                            // Parse a valid integer using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.incrementEnum();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 2:
                            // Parse an invalid value using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();
                            
                            myenum.incrementEnum();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 3:
                            // Parse an invalid value using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.incrementEnum();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;

                        default:
                            break;
                    }

                    // Skip over the time for the first operation,
                    // just in case it caused a one-time
                    // performance hit.
                    if (i == 0)
                    {
                        time10kOperations.Reset();
                        time10kOperations.Start();
                    }
                    else 
                    {

                        // Update operation statistics
                        // for iterations 1-10001.
                        if (maxTicks < ticksThisTime)
                        {
                            indexSlowest = i;
                            maxTicks = ticksThisTime;
                        }
                        if (minTicks > ticksThisTime)
                        {
                            indexFastest = i;
                            minTicks = ticksThisTime;
                        }
                        numTicks += ticksThisTime;
                        if (numTicks < ticksThisTime)
                        {
                            // Keep track of rollovers.
                            numRollovers ++;
                        }
                    }
                }  
                
                // Display the statistics for 10000 iterations.

                time10kOperations.Stop();
                milliSec = time10kOperations.ElapsedMilliseconds;

                Console.WriteLine();
                Console.WriteLine("{0} Summary:", operationNames[operation]);
                Console.WriteLine("  Slowest time:  #{0}/{1} = {2} ticks",
                    indexSlowest, numIterations, maxTicks);
                Console.WriteLine("  Fastest time:  #{0}/{1} = {2} ticks",
                    indexFastest, numIterations, minTicks);
                Console.WriteLine("  Average time:  {0} ticks = {1} nanoseconds", 
                    numTicks / numIterations, 
                    (numTicks * nanosecPerTick) / numIterations );
                Console.WriteLine("  Total time looping through {0} operations: {1} milliseconds", 
                    numIterations, milliSec);
            }
        }
        
        private static void TimeOperationsLinqAsParallel()
        {
            long nanosecPerTick = (1000L*1000L*1000L) / Stopwatch.Frequency;
            const long numIterations = 10000;

            // Define the operation title names.
            String [] operationNames = {"Operation: TimeOperationsLinq(\"0\")",
                                           "Operation: TimeOperationsLinq(\"0\")",
                                           "Operation: TimeOperationsLinq(\"a\")",
                                           "Operation: TimeOperationsLinq(\"a\")"};

            // Time four different implementations for parsing 
            // an integer from a string. 

            for (int operation = 0; operation <= 3; operation++)
            {
                // Define variables for operation statistics.
                long numTicks = 0;
                long numRollovers = 0;
                long maxTicks = 0;
                long minTicks = Int64.MaxValue;
                int indexFastest = -1;
                int indexSlowest = -1;
                long milliSec = 0;

                Stopwatch time10kOperations = Stopwatch.StartNew();

                // Run the current operation 10001 times.
                // The first execution time will be tossed
                // out, since it can skew the average time.

                var myenum = new EnumTest();
                
                for (int i=0; i<=numIterations; i++) 
                {
                    long ticksThisTime = 0;
                    int inputNum;
                    Stopwatch timePerParse;

                    switch (operation)
                    {
                        case 0:
                            // Parse a valid integer using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            //run Enums test:
                            
                            myenum.incrementEnumParallel();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.

                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 1:
                            // Parse a valid integer using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.incrementEnumParallel();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 2:
                            // Parse an invalid value using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();
                            
                            myenum.incrementEnumParallel();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 3:
                            // Parse an invalid value using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.incrementEnumParallel();

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;

                        default:
                            break;
                    }

                    // Skip over the time for the first operation,
                    // just in case it caused a one-time
                    // performance hit.
                    if (i == 0)
                    {
                        time10kOperations.Reset();
                        time10kOperations.Start();
                    }
                    else 
                    {

                        // Update operation statistics
                        // for iterations 1-10001.
                        if (maxTicks < ticksThisTime)
                        {
                            indexSlowest = i;
                            maxTicks = ticksThisTime;
                        }
                        if (minTicks > ticksThisTime)
                        {
                            indexFastest = i;
                            minTicks = ticksThisTime;
                        }
                        numTicks += ticksThisTime;
                        if (numTicks < ticksThisTime)
                        {
                            // Keep track of rollovers.
                            numRollovers ++;
                        }
                    }
                }  
                
                // Display the statistics for 10000 iterations.

                time10kOperations.Stop();
                milliSec = time10kOperations.ElapsedMilliseconds;

                Console.WriteLine();
                Console.WriteLine("{0} Summary:", operationNames[operation]);
                Console.WriteLine("  Slowest time:  #{0}/{1} = {2} ticks",
                    indexSlowest, numIterations, maxTicks);
                Console.WriteLine("  Fastest time:  #{0}/{1} = {2} ticks",
                    indexFastest, numIterations, minTicks);
                Console.WriteLine("  Average time:  {0} ticks = {1} nanoseconds", 
                    numTicks / numIterations, 
                    (numTicks * nanosecPerTick) / numIterations );
                Console.WriteLine("  Total time looping through {0} operations: {1} milliseconds", 
                    numIterations, milliSec);
            }
        }
        
        private static void TimeOperationsDict()
        {
            long nanosecPerTick = (1000L*1000L*1000L) / Stopwatch.Frequency;
            const long numIterations = 10000;

            // Define the operation title names.
            String [] operationNames = {"Operation: TimeOperationsDict(\"0\")",
                                           "Operation: TimeOperationsDict(\"0\")",
                                           "Operation: TimeOperationsDict(\"a\")",
                                           "Operation: TimeOperationsDict(\"a\")"};

            // Time four different implementations for parsing 
            // an integer from a string. 

            for (int operation = 0; operation <= 3; operation++)
            {
                // Define variables for operation statistics.
                long numTicks = 0;
                long numRollovers = 0;
                long maxTicks = 0;
                long minTicks = Int64.MaxValue;
                int indexFastest = -1;
                int indexSlowest = -1;
                long milliSec = 0;

                Stopwatch time10kOperations = Stopwatch.StartNew();

                // Run the current operation 10001 times.
                // The first execution time will be tossed
                // out, since it can skew the average time.

                var myenum = new DictionaryTest();
                var value = 0;
                
                for (int i=0; i<=numIterations; i++) 
                {
                    long ticksThisTime = 0;
                    int inputNum;
                    Stopwatch timePerParse;

                    switch (operation)
                    {
                        case 0:
                            // Parse a valid integer using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            //run Enums test:
                            
                            myenum.currentEnum++;
                            DictionaryTest.MyList.TryGetValue(myenum.currentEnum.ToString(), out value); 

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.

                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 1:
                            // Parse a valid integer using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.currentEnum++;
                            DictionaryTest.MyList.TryGetValue(myenum.currentEnum.ToString(), out value);

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 2:
                            // Parse an invalid value using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();
                            
                            myenum.currentEnum++;
                            DictionaryTest.MyList.TryGetValue(myenum.currentEnum.ToString(), out value);

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 3:
                            // Parse an invalid value using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            myenum.currentEnum++;
                            DictionaryTest.MyList.TryGetValue(myenum.currentEnum.ToString(), out value);

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;

                        default:
                            break;
                    }

                    // Skip over the time for the first operation,
                    // just in case it caused a one-time
                    // performance hit.
                    if (i == 0)
                    {
                        time10kOperations.Reset();
                        time10kOperations.Start();
                    }
                    else 
                    {

                        // Update operation statistics
                        // for iterations 1-10001.
                        if (maxTicks < ticksThisTime)
                        {
                            indexSlowest = i;
                            maxTicks = ticksThisTime;
                        }
                        if (minTicks > ticksThisTime)
                        {
                            indexFastest = i;
                            minTicks = ticksThisTime;
                        }
                        numTicks += ticksThisTime;
                        if (numTicks < ticksThisTime)
                        {
                            // Keep track of rollovers.
                            numRollovers ++;
                        }
                    }
                }  
                
                // Display the statistics for 10000 iterations.

                time10kOperations.Stop();
                milliSec = time10kOperations.ElapsedMilliseconds;

                Console.WriteLine();
                Console.WriteLine("{0} Summary:", operationNames[operation]);
                Console.WriteLine("  Slowest time:  #{0}/{1} = {2} ticks",
                    indexSlowest, numIterations, maxTicks);
                Console.WriteLine("  Fastest time:  #{0}/{1} = {2} ticks",
                    indexFastest, numIterations, minTicks);
                Console.WriteLine("  Average time:  {0} ticks = {1} nanoseconds", 
                    numTicks / numIterations, 
                    (numTicks * nanosecPerTick) / numIterations );
                Console.WriteLine("  Total time looping through {0} operations: {1} milliseconds", 
                    numIterations, milliSec);
            }
        }
    }
}
