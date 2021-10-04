namespace SlavaAlgorithms

open System.Linq
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
module Permutations = 
    let FactorialAlg(arr:seq<'a>) = 
        
        let rec getPermutations(arr:seq<'a>):seq<'a> =
            for y = 0 to arr.Count()-1 do
                let el = (Seq.take y arr).First()
                let newArr = arr |> Seq.filter(fun x-> x <> el)
                let newRes = getPermutations(newArr)
                let dec = [el].Concat(newRes)
                dec
                    
            Seq.empty    
        getPermutations(arr)   
           
