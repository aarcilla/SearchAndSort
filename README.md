# Search And Sort
## Introduction
Search And Sort is a basic PC application that allows for searching (a particular integer) and sorting within a collection of integers. Multiple prominent search and sort algorithms are provided.

## Purpose
Nothing special. Served as a means of practice and revision of WPF design and development, search & sort algorithms, and unit testing, as well as .NET & C# in general.

## Technologies
* **Framework & language**: WPF 4.5, .NET 4.5 & C# 5.0
* **IDE**: Visual Studio Community 2013
* **Source control**: Git
* **Unit testing**: Visual Studio Unit Testing

## Features
* Straightforward GUI: UI elements are clearly labelled, help messages are displayed when appropriate, and any user errors are addressed to the user
* Parses a string of a collection of integers entered by the user
* Search algorithms: linear, binary (if pre-sorted)
* Sort algorithms: selection, insertion, bubble, quicksort, merge, heapsort
* Sort by either ascending (default) or descending orders

## Known limitations/issues
* Only integer numbers supported; no decimal numbers
* Doesn't support numbers containing commas (,) or full stops (.) (e.g. ten thousand: 10,000 or 10.000)
* Doesn't support numbers smaller than -2147483648 (integer minimum value) or larger than 2147483647 (integer maximum value)