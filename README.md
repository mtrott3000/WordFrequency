# WordFrequency

This repository contains 3 methods that can be used, all of them reference the SortWordsIntoFrequencyOrder method.

## SortWordsIntoFrequencyOrder(string text)

This method seperates the text by spacing.
Then it will check to make sure that the seperated words definitely meet the conditions of a-z and A-Z, if not an ArgumentOutOfRange exception will be thrown.
Next it will loop over all of the split words.
Within the loop it will check to see if the current word is in the sorted list:
- If it is, then it will add 1 to the Frequency property of the WordFrequency object.
- If it is not, then it will add that WordFrequency object to the list.

The method then returns the sortedList, ordering alphabetically first based on the Word property, and then it will order by the Frequency descending.

## CalculateHighestFrequency(string text)

This method returns the Frequency property of the first element in the list, which is returned by the SortWordsIntoFrequencyOrder method.

## CalculateFrequencyForWord(string text, string word)

This method will check the returned list from the SortWordsIntoFrequencyOrder method, to see if the "word" parameter is contained in the list.
- If it is, then it will return the Frequency property of that WordFrequency object.
- If it is not, then it will return 0.

## CalculateMostFrequentWords(string text, int number)

This method will check to see if the number parameter provided is greater than the count of the list returned by the SortWordsIntoFrequencyOrder method.
- If it is, then it will return the entire list.
- If it is not, then it will get the get the first n elements from the list (where n is number).
  Then it will get the Frequency value from the last object in the new sub list.	
  After that, it will then get all elements in the original sorted list, where the Frequency property is greater than or equal to that.