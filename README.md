# RandSort

## Blazingly slow sorting algorithm based on randomly attempting swapping numbers around in an array and hoping we stumble upon the solution

**WARNING: Turn back. There's nothing of import for you here.**

Tired of **efficient** sorting algorithms? Want your software to **grind down to a halt** given a 
slightly large array of integers? Looking to surrender your code to the **gods of chaos**? Wanna 
see all 16 processor cores spike to **100% for minutes at a time**? Well look no further! 
**RandSort** is here!

Listen, we all love our efficient binary and cute bubble sorts. But do you know what they don't 
have? Horrifically unoptimized code with a heavy dose of randomization. That's where RandSort comes 
in. 

## How it Works

Shocking, I know, but this actually does sort arrays. Here's how (brace yourself): 

1. Split the source array into chunks and start a Task to sort each chunk asynchronously.
2. Check all items in the array to see if they're sorted. If they are, return the sorted array.
3. Loop through each item and check whether all items on the left of it are smaller and all 
items on the right are bigger. If they are, lock the position as that number is sorted.
4. Loop through all items in the array and swap each one with another from a random position. Only 
unlocked positions are available for swapping.
5. Go back to 2.

When all chunks are sorted, they are then merged back together and returned.

<p align="center">
  <img src="https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExaDYxMWFoZzdncDFybmE1ZHRmMWx0eWh5OWNwZG94d3RkcG1pdnk5diZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/s239QJIh56sRW/giphy.webp" />
</p>

You are asking the wrong question. "Why not?" is also the wrong question. The correct question is "What 
could possibly have possessed you to waste 2 hours working on this nonsense?" And the answer is complicated. 
See, I've been doing leetcode problems for a month in an attempt to `git gud` and my brain is fried. Experience 
has taught me that the best way to unfry your brain is to do something stupid just for fun. **It doesn't get 
any stupider than this.**

Guess the answer wasn't as complicated as I originally let on.

## Isn't Chunking TOO efficient?

I concede that chunking was done to improve performance and you may be asking "Why on Earth would you do that?" 
The answer is simple: any array larger than 300-400 would just take more than a minute finish. With 1000 items, 
the sort would never actually finish. The number of open positions for randomization was too large to ever 
stumble onto a solution.

Chunking helps solve this problem by keeping RandSort **blazingly slow**, but able to finish a sort in a human's 
very short lifetime.

The size of chunks can be adjusted. If you use small chunks you're actually committing a crime (the merge algorithm 
is (slightly more) efficient (than the all-random search)) and if you use chunks too large then you'll never 
see the array sorted. A good middle-ground seems to be around 300 items per chunk to get that authentic 
RandSort experience.

## Let's Talk Results!

It's shit. Where you expecting otherwise?

<p align="center">
  <img src="https://raw.githubusercontent.com/criticalsession/RandSort/master/Results/cpu_oopsie.png" />
</p>

This is your CPU on RandSort.

<p align="center">
  <img src="https://raw.githubusercontent.com/criticalsession/RandSort/master/Results/randsort_results.png" />
</p>

As can be seen by this top quality chart, the larger the chunk size the slower **RandSort** becomes. This is 
because the larger the chunk of the array the harder it becomes to randomly manage to place the number in the 
correct position. On the flip side, the smaller the chunk the bigger the influence that the more efficient 
merge at the end has on the overall output. A chunk size of 5 takes 1.5ms to sort 1k items.

Another side-effect of the chunking system is that when the array grows larger than the size of the chunks, the 
time it takes to sort the array plateaus. This is because chunks are sorted asynchronously using Tasks so the 
effect on time to sort is minimal.