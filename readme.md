Timings comparing [Scatter vs Gather](https://en.wikipedia.org/wiki/Gather-scatter_(vector_addressing) algorithms.
Timings done on Release builds without debugger attached.

Processor	Intel(R) Core(TM) i7-7500U CPU @ 2.70GHz, 2904 Mhz, 2 Core(s), 4 Logical Processor(s)

Time to  Scatter  100000000 items        1 times:  1438ms = 14.38ns per integer copy
Time to   Gather  100000000 items        1 times:  2066ms = 20.66ns per integer copy
Time to  Scatter   10000000 items       10 times:  1150ms =  11.5ns per integer copy
Time to   Gather   10000000 items       10 times:  1362ms = 13.62ns per integer copy
Time to  Scatter    1000000 items      100 times:   419ms =  4.19ns per integer copy
Time to   Gather    1000000 items      100 times:   664ms =  6.64ns per integer copy
Time to  Scatter     100000 items     1000 times:   230ms =   2.3ns per integer copy
Time to   Gather     100000 items     1000 times:   234ms =  2.34ns per integer copy
Time to  Scatter      10000 items    10000 times:   162ms =  1.62ns per integer copy
Time to   Gather      10000 items    10000 times:   140ms =   1.4ns per integer copy
Time to  Scatter       1000 items   100000 times:   151ms =  1.51ns per integer copy
Time to   Gather       1000 items   100000 times:   136ms =  1.36ns per integer copy
Time to  Scatter        100 items  1000000 times:   163ms =  1.63ns per integer copy
Time to   Gather        100 items  1000000 times:   145ms =  1.45ns per integer copy

Processor	Intel(R) Core(TM) i7-7820X CPU @ 3.60GHz, 3601 Mhz, 8 Core(s), 16 Logical Processor(s)

Time to  Scatter  100000000 items        1 times:  1073ms = 10.73ns per integer copy
Time to   Gather  100000000 items        1 times:  1251ms = 12.51ns per integer copy
Time to  Scatter   10000000 items       10 times:   744ms =  7.44ns per integer copy
Time to   Gather   10000000 items       10 times:   945ms =  9.45ns per integer copy
Time to  Scatter    1000000 items      100 times:   346ms =  3.46ns per integer copy
Time to   Gather    1000000 items      100 times:   294ms =  2.94ns per integer copy
Time to  Scatter     100000 items     1000 times:   110ms =   1.1ns per integer copy
Time to   Gather     100000 items     1000 times:   104ms =  1.04ns per integer copy
Time to  Scatter      10000 items    10000 times:    94ms =  0.94ns per integer copy
Time to   Gather      10000 items    10000 times:    83ms =  0.83ns per integer copy
Time to  Scatter       1000 items   100000 times:    94ms =  0.94ns per integer copy
Time to   Gather       1000 items   100000 times:    82ms =  0.82ns per integer copy
Time to  Scatter        100 items  1000000 times:    99ms =  0.99ns per integer copy
Time to   Gather        100 items  1000000 times:    87ms =  0.87ns per integer copy