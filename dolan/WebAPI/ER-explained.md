# BAD - Chen Notation Diagram

## 1. Introduction

The diagram enclosed in the zip folder is a chen notation ER diagram. The point of the diagram is to visualize how the database relationships and table relate to each other. The code for creating the database abbreviations have been used. These abbreviations are not present in the Chen notation ER diagram. But will be used in this text.

| Abbreviation | Meaning                   |
| ------------ | ------------------------- |
| `ProvId`     | Provider ID               |
| `BPA`        | Business Physical Address |
| `GId`        | Guest ID                  |
| `EId`        | Experience ID             |
| `SEId`       | Shared Experience ID      |
| `SE`         | Shared Experience         |
| `SEDets`     | Shared Experience Details |
| `SEGuest`    | Shared Experience Guest   |

## 2. Entities and attributes

The main entities in my ER diagram are the Provider, Guest, Experience and Shared Experience. Each of them have different attributes which can be seen in the following.

### Provider

Represents businesses offering experiences.  
**Attributes:**

- `Provider_Id` – Unique identifier for providers (Primary Key)
- `Business Physical Address` – Physical address of the provider
- `CVR` – Central Business Register Number
- `Phone Number` – Contact number of the provider
- `Name` – Name of the provider

### Guest

Represents individuals attending shared experiences.  
**Attributes:**

- `Guest_Id` – Unique identifier for guests (Primary Key)
- `Phone Number` – Contact number of the guest
- `Name` – Name of the guest
- `Age` – Age of the guest

### Experience

Represents different activities offered by providers.  
**Attributes:**

- `Experience_Id` – Unique identifier for experiences (Primary Key)
- `Name` – Name of the experience
- `Price` – Cost of the experience
- `Provider_Id` – Foreign key referencing Provider
- `Description` – Details about the experience

### Shared Experience

Represents events that consist of one or more experiences.  
**Attributes:**

- `Shared_Experience_Id` – Unique identifier for shared experiences (Primary Key)
- `Name` – Name of the shared experience
- `Date` – Date of the shared experience

## Relationships

The attributes and entities above have been outlined. Now for the relationship between each of the entities. The relationships are as follows:

- `Provider` has a relationship of 1:M to experience, because an experience is provided by one provider, but one provider can `Provide` multiple experiences.
- `Guest` has a relationship of M:M to experiences AND SE, because a guest can `Attend` multiple experiences and SE. The experience and SE can also have many guests attending it.
- `Experience` has a relationship of M:M to SE because an experience can be a part of multiple SE. A SE `Consists of` many experiences.
