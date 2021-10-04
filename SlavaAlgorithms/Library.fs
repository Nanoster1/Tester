namespace SlavaAlgorithms

module Fibonachi =
    let LazyAlg num = 
        seq{
            let mutable index = 0
            
            let mutable num = 0
            if index <= num then
                yield num
            let mutable nextnum = 1
            if index <= num then
                yield nextnum
            while index <= num do 
                let saveNum = nextnum                                        
                nextnum <- num + nextnum    
                num <- saveNum
                yield nextnum
            }        
        
