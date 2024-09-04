# RandSort

**WARNING: This is a work in progress. Do not use it. Eventually it will be done, and even then you shouldn't use it.**

---

Tired of **efficient** sorting algorithms? Want your software to **grind down to a halt** given a 
slightly large array of integers? Looking to surrender your code to the **gods of chaos**? Wanna 
see all 16 processor cores spike to **100% for minutes at a time**? Well look no further! 
**RandSort** is here!

Listen, we all love our efficient binary and cute bubble sorts. But do you know what they don't 
have? Horrifically unoptimized code with a heavy dose of randomization. That's where RandSort comes 
in. 

## How it Works

Shocking, I know, but this actually does sort arrays. Here's how (brace yourself): 

1. Split the source array into chunks and start a Task to sort each chunk separately.
2. Check all items in the array to see if they're sorted. If they are, return the sorted array.
3. Loop through each item and check whether all items on the left of it are smaller and all 
items on the right are bigger. If they are, lock the position as the number is sorted.
4. Loop through all items in the array and swap each one with another from a random position. Only 
unlocked positions are available for swapping.
5. Go back to 1.

When all chunks are sorted, they are then merged back together and returned.

## But... Why?

![but Why gif](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExaDYxMWFoZzdncDFybmE1ZHRmMWx0eWh5OWNwZG94d3RkcG1pdnk5diZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/s239QJIh56sRW/giphy.webp)

You are asking the wrong question. "Why not?" is also the wrong question. The correct question is "What 
could possibly have possessed you to waste 2 hours working on this nonsense?" And the answer is complicated. 
See, I've been doing leetcode problems for a month in an attempt to `git gud` and my brain is fried. Experience 
has taught me that the best way to unfry your brain is to do something stupid just for fun. It doesn't get 
**any stupider than this.**

Guess the answer wasn't as complicated as I originally let on.

## Isn't Chunking TOO efficient?

I concede that chunking was done to improve performance and you may be asking "Why on Earth would you do that?" 
The answer is simple: any array larger than 300-400 would just take more than a minute sometimes to finish. With
a 1000 items, the sort would never actually finish. The number of open positions for randomization was too large 
to ever stumble onto a solution.

Chunking helps solve this problem by keeping RandSort blazingly slow, but able to finish a sort in a human's 
very short lifetime.

The size of chunks can be adjusted. If you use small chunks you're actually cheating (the merge algorithm 
is (slightly more) efficient (than the all-random search)) and if you use chunks too large then you'll never 
see the array sorted. A good middle-ground seems to be around 300 items per chunk to get that authentic 
RandSort experience.