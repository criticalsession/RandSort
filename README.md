# RandSort

**WARNING: This is a work in progress. Do not use it. It doesn't even sort `odd` length arrays. Eventually 
it will be done, and even then you shouldn't use it.**

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

1. Check all items in the array to see if they're sorted. If they are, return the sorted array.
2. Loop through each item and check whether all items on the left of it are smaller and all 
items on the right are bigger. If they are, lock the position as the number is sorted.
3. Loop through all items in the array and swap each one with another from a random position. Only 
unlocked positions are available for swapping.
4. Go back to 1.

This obviously only works if multiple Tasks are launched to handle the array. *Do not* run this with 
a single Task. Or do, I don't care, I'm not your dad.

## But... Why?

![but Why gif](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExaDYxMWFoZzdncDFybmE1ZHRmMWx0eWh5OWNwZG94d3RkcG1pdnk5diZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/s239QJIh56sRW/giphy.webp)

You are asking the wrong question. "Why not?" is also the wrong question. The correct question is "What 
could possibly have possessed you to waste 2 hours working on this nonsense?" And the answer is complicated. 
See, I've been doing leetcode problems for a month in an attempt to `git gud` and my brain is fried. Experience 
has taught me that the best way to unfry your brain is to do something stupid just for fun. It doesn't get 
**any stupider than this.**

Guess the answer wasn't as complicated as I originally let on.
