# EnumLinqVsDictImperative
Just a quick test to compare enum key value if not sequential vs enum + dict lookup if imperative.


Operations timed using the system's high-resolution performance counter.
  Timer frequency in ticks per second = 10000000
  Timer is accurate within 100 nanoseconds
  
##Linq Parallel
Operation: TimeOperationsLinq("0") Summary:
  Slowest time:  #612/10000 = 9720 ticks
  Fastest time:  #4767/10000 = 147 ticks
  Average time:  223 ticks = 22358 nanoseconds
  Total time looping through 10000 operations: 224 milliseconds
Operation: TimeOperationsLinq("0") Summary:
  Slowest time:  #5041/10000 = 3628 ticks
  Fastest time:  #5375/10000 = 127 ticks
  Average time:  204 ticks = 20441 nanoseconds
  Total time looping through 10000 operations: 205 milliseconds
Operation: TimeOperationsLinq("a") Summary:
  Slowest time:  #4673/10000 = 2474 ticks
  Fastest time:  #2068/10000 = 145 ticks
  Average time:  193 ticks = 19342 nanoseconds
  Total time looping through 10000 operations: 194 milliseconds
Operation: TimeOperationsLinq("a") Summary:
  Slowest time:  #2264/10000 = 3081 ticks
  Fastest time:  #9922/10000 = 138 ticks
  Average time:  197 ticks = 19718 nanoseconds
  Total time looping through 10000 operations: 198 milliseconds
  
##Dictionary + Enum, Imperative
Operation: TimeOperationsDict("0") Summary:
  Slowest time:  #2/10000 = 307 ticks
  Fastest time:  #4264/10000 = 0 ticks
  Average time:  1 ticks = 116 nanoseconds
  Total time looping through 10000 operations: 1 milliseconds
Operation: TimeOperationsDict("0") Summary:
  Slowest time:  #4612/10000 = 76 ticks
  Fastest time:  #3/10000 = 1 ticks
  Average time:  1 ticks = 114 nanoseconds
  Total time looping through 10000 operations: 1 milliseconds
Operation: TimeOperationsDict("a") Summary:
  Slowest time:  #9002/10000 = 9 ticks
  Fastest time:  #3/10000 = 1 ticks
  Average time:  1 ticks = 113 nanoseconds
  Total time looping through 10000 operations: 1 milliseconds

Operation: TimeOperationsDict("a") Summary:
  Slowest time:  #1357/10000 = 77 ticks
  Fastest time:  #1/10000 = 1 ticks
  Average time:  1 ticks = 116 nanoseconds
  Total time looping through 10000 operations: 1 milliseconds
  
##Linq Enum
Operation: TimeOperationsLinq("0") Summary:
  Slowest time:  #1/10000 = 99 ticks
  Fastest time:  #11/10000 = 6 ticks
  Average time:  7 ticks = 712 nanoseconds
  Total time looping through 10000 operations: 7 milliseconds

Operation: TimeOperationsLinq("0") Summary:
  Slowest time:  #1072/10000 = 824 ticks
  Fastest time:  #21/10000 = 6 ticks
  Average time:  7 ticks = 722 nanoseconds
  Total time looping through 10000 operations: 7 milliseconds

Operation: TimeOperationsLinq("a") Summary:
  Slowest time:  #9739/10000 = 815 ticks
  Fastest time:  #8/10000 = 6 ticks
  Average time:  7 ticks = 722 nanoseconds
  Total time looping through 10000 operations: 7 milliseconds

Operation: TimeOperationsLinq("a") Summary:
  Slowest time:  #8639/10000 = 130 ticks
  Fastest time:  #11/10000 = 6 ticks
  Average time:  7 ticks = 715 nanoseconds
  Total time looping through 10000 operations: 7 milliseconds

# Remarks:
Please note that this is definitely not a great test yet, still need to make the dictionary version have the default or have linq try/catch instead of default with catch just not doing anything.

Please also note that this is a test for a system where this sectino of code will be run hundreds of times, but only once every 1/3/30 seconds (the main reason for the design) with the lookup of the value of the dict happening very often. 

I also need to make sure that the dictioniary try/get is actually being assigned and not skipped by the compiler as 1 tick might allude to. 
