namespace Algorithms.SecondTask

open Tester.Meta.Models
open System.Linq

module MatrixAlgorithm =
    let MullMatrix(matrixA: int[][],matrixB : int[][])  =
        let size = new System.Drawing.Point(matrixA.Length,matrixB.First().Length)
        if not (matrixA.First().Length = matrixB.Length) then
            (new Matrix(0,0)).ToArray()
        else            
            let matrix = [for o=0 to size.Y - 1 do
                            let column = 
                                [for i =0 to size.Y - 1 do
                                    let mutable num = 0
                                    for j = 0 to size.X - 1 do
                                        num <- num + matrixA.[o].[j] * matrixB.[j].[i]
                                    yield num]
                            yield column]
            (matrix.Select(fun x -> x.ToArray())).ToArray()