namespace SlavaAlgorithms

open System.Linq
open System.Numerics

module Fibonachi =
    let LazyAlg num2:seq<BigInteger> = 
        seq{
            let mutable index = 0
            
            let mutable num = new BigInteger(0)
            if index <= num2 then
                yield num
            let mutable nextnum = new BigInteger(1)
            if index <= num2 then
                yield nextnum
            while index <= num2 do 
                let saveNum = nextnum                                        
                nextnum <- num + nextnum    
                num <- saveNum
                yield nextnum
            }        
module Permutations = 
    let FactorialAlg(arr:'b list) = 
        
        let rec distribute e = function
            | [] -> [[e]]
            | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

        let rec permute = function
            | [] -> [[]]
            | e::xs -> List.collect (distribute e) (permute xs)  
        permute arr
           
