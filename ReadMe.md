# Simple Test

Designed to demonstrate the basics of prescribed test for:

1. Querying capabilities with LINQ
2. Func's
3. Entity Framework Code First and ability to query live data
4. Unit testing and Database First examples are supplied as separate GitHub repositories written in the past 

## Structure

```
|   - Entities
|   - EntitiesService
|   - SimpleTest
```

### Entities

**Class library:** initial implementation of database entities. Includes entities:

- Student
- Faculty
- StudentFaculty
- Fluent Api
  - Constraints
  - Many to many configuration
  - Index's
  - Unique constraint
- Data annotations
  - Required
  - String lengths

Supports criteria - query students assigned to faculty: Medicine and demonstrates utilization of Func

### EntitiesService

**Class library:** initial implementation facilitating generic CRUD functionality.

Supports criteria - query students assigned to faculty: Medicine and demonstrates utilization of Func

### SimpleTest

**Console application:** demonstrating:

**Ability to filter a collection of numbers (odd and even) by:**

1. Even numbers - implementing the modulus operator: `collection.Where(p => p % 2 == 0)`
2. Sorted in ascending order: `collection.OrderBy(p => p)`


**Ability to understand Func's:**

Whilst I don't use this strategy on a regular basis, I do have an understanding of how to implement and create additional implementations for future use cases.

**Ability to Query Data:**

Above an beyond - implementing the ability to:

- Create a database - configured locally
- Automatically run Entity Framework schema migrations
- Seed data id none already exist
- TSQL scripts

All this to showcase real world use of querying data:

1. Student: A student can have 0, 1 or many Faculties
2. Faculty: A faculty can have 0, 1 or many Students

```
Students < 1 to many > StudentFaculty < many to 1 > Faculties
```

##  Additional Examples

For an example of Database First (reverse engineering) pleas look at my GitHub repo: [Entity Framework - Database First](https://github.com/lightspaceliam/database-first-reverse-engineering-poc)

For an example of Unit Testing  pleas look at my GitHub repo:
[Unit Testing Strategies](https://github.com/lightspaceliam/unit-testing-strategies/tree/main) 