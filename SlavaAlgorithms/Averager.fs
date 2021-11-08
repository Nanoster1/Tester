namespace SlavaAlgorithms

open System
open System.Collections.Generic

type Averager(countFunction:Func<float>, averageDegree) =
    let queue = new Queue<float>()
    let mutable sum = 0.0;
    member this.Measure() =        
        let value = countFunction.Invoke()
        queue.Enqueue value
        sum <- sum + value
        if queue.Count > averageDegree then
            sum <- sum - queue.Dequeue()
        sum / float queue.Count

