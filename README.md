![build](https://github.com/amlsantos/ExpressionTree-tdd-kata/actions/workflows/build.yml/badge.svg)
![test](https://github.com/amlsantos/ExpressionTree-tdd-kata/actions/workflows/test.yml/badge.svg)

# Expression Tree Kata

## Introduction

This is a sample coding exercise, designed to practice Test-Driven Development (TDD) using .NET. 
This kata models an infix notation into an expression tree.
Please watch this video for more insights: [The Clean Code Talks - Inheritance, Polymorphism, & Testing](https://www.youtube.com/watch?v=4F72VULWFvc).

## Project Highlights

- **Design Patterns**: The solution incorporates the Command Design Pattern and the State Pattern to provide a flexible and extensible structure.
- **TDD (Test-Driven Development)**: The development process follows TDD principles, ensuring that tests are written before the corresponding code.

## Getting Started

### Prerequisites

Make sure you have the following installed on your machine:

- [.NET](https://dotnet.microsoft.com/download)

### Clone the Repository

```bash
git clone https://github.com/amlsantos/ExpressionTree-tdd-kata.git
cd ExpressionTree-tdd-kata
```

### Build and Run Tests
```bash
dotnet build
dotnet test
```

# Expression tree Kata - Requirements

This coding exercise aims to convert an infix notation as (1+1)*(1+1) into an expression tree.
An expression tree is a tree-like data structure, used to represent expressions in a mathematical or logical form. 
The nodes of the tree represent operators and operands, and the edges represent the relationships between them.

Here's how an expression tree works:
- Values: The operands of the expression are represented as the leaves of the tree. These are the values or variables involved in the expression.
- Operators: The operators in the expression are represented as the internal nodes of the tree. Each node corresponds to an operator and has child nodes that represent its operands.
- Edges: The edges of the tree connect the operators to their respective operands, showing the relationships and order of evaluation.

For example, consider the infix expression: 3 + 4 * 5. In an expression tree, it might look like this:

```plaintext
    +
   / \
  3   *
     / \
    4   5
```

# Expression tree Kata - Project Structure

This section provides an overview of the project structure for the Expression tree Kata.

## Directory Structure

```plaintext
ExpressionTree-tdd-kata/
|-- src/
|   |-- Domain/
|       |-- Nodes/
|       |-- ExpressionTree.cs
|   |-- UI/
|           |-- Program.cs
|-- tests/
|   |-- UnitTests/
|       |-- ExpressionTreeTests.cs
|-- .gitignore
|-- Expression.sln
|-- README.md
```

# To Do 

- As of today, we only support simple infix operations as 1 + 1. In a future, we would like to be able to construct more complex expression trees, to support more complex infix notation operations.


# Mars Rovers Kata - Acknowledgments

- [The Clean Code Talks - Inheritance, Polymorphism, & Testing](https://www.youtube.com/watch?v=4F72VULWFvc): For the video that inspired this repo.



