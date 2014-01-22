let rec quicksort2 = function
    | [] -> []
    | first::rest ->
        let smaller, larger = List.partition ((>=) first) rest
        List.concat [quicksort2 smaller; [first]; quicksort2 larger]

//test code
printfn "%A" (quicksort2 [1;5;23;18;9;1;3])
