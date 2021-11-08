namespace SlavaAlgorithms

open System.Linq
open System.Numerics

module Fibonachi =
    let LazyAlg num2 = 
            
            let mutable num = new BigInteger(0)
            let mutable nextnum = new BigInteger(1)
            [   
                yield new BigInteger(1)     
                for i in 2..num2 ->
                    let saveNum = nextnum                                        
                    nextnum <- num + nextnum    
                    num <- saveNum
                    nextnum]
                   
module Permutations = 
    let FactorialAlg(arr:'b list) = 
        
        let rec distribute e = function
            | [] -> [[e]]
            | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

        let rec permute = function
            | [] -> [[]]
            | e::xs -> List.collect (distribute e) (permute xs)  
        permute arr
           
