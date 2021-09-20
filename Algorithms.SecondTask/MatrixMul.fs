namespace Algorithms.SecondTask

open Tester.Meta.Models

module MatrixAlgorithm =
    let MullMatrix(matrixA: Matrix,matrixB : Matrix)  =
        let size = new System.Drawing.Point(matrixA.Count.X,matrixB.Count.Y)
        if not (matrixA.Count.Y = matrixB.Count.X) then
            new Matrix(0,0)
        else
            let matrix = new Matrix(size)
            
            matrix
        
