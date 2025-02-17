CREATE DATABASE experienceSharedDb;
GO

USE experienceSharedDb;
CREATE TABLE Guests
(
    GuestId INT PRIMARY KEY,
    GuestName NVARCHAR(50),
    GuestPhoneNumber NVARCHAR(50),
    GuestAge INT
);