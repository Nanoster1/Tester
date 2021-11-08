module AnalysisText

open System.Collections.Generic

let IsCorrectBrackets text = 
    let pairs = new Dictionary<char, char>()
    pairs.Add('(', ')')
    pairs.Add('[', ']')
    pairs.Add('<', '>')
    pairs.Add('{', '}')
    pairs.Add('/', '\\')
    let stack = new Stack<char>()
    for letter in text do
        if pairs.ContainsKey letter then
            stack.Push(letter)
        else if pairs.ContainsValue letter  then 
            if pairs.Count <> 0 && pairs.[stack.Peek()] = letter then
                stack.Pop() |> ignore
    stack.Count = 0;
