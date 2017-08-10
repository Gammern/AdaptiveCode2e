## Solution MyAccounting

### Project MyAccounting
netstandard1.1 library. Contains Account and several RewardCards. Use the null object pattern 
to represent a reward card for standard account. Account factory has two functions to create an
account. One is typesafe (enum), the other one is not (string).

### MyAccounting.Tests
netcoreapp1.1 MS Test project. Use reflection to get private IRewardCard property from Account.  

All changes from chapter 5 are squashed into master branch. Detailed commit history (refactoring) 
can be found in branch [Chap6](https://github.com/Gammern/AdaptiveCode2e/commits/Chap6). 
Follow trail from "Merge chap5".