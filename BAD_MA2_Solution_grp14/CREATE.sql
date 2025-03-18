-- CREATE DATABASE experienceSharedDb;
-- GO
USE experienceSharedDb;

CREATE TABLE Providers (
    ProvId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    BPA NVARCHAR(255) NOT NULL,
    PhoneNum NVARCHAR(20) NOT NULL,
    CVR NVARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE Guests (
    GId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    PhoneNum NVARCHAR(20) NOT NULL
);

CREATE TABLE Experiences (
    EId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description TEXT,
    ProvId INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProvId) REFERENCES Providers(ProvId)
);

CREATE TABLE SE (
    SEId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Date DATETIME NOT NULL,
);

-- Junction table linking Shared Experiences with Experiences 
CREATE TABLE SEDets (
    SEId INT NOT NULL,
    EId INT NOT NULL,
    PRIMARY KEY (SEId, EId),
    FOREIGN KEY (SEId) REFERENCES SE(SEId),
    FOREIGN KEY (EId) REFERENCES Experiences(EId)
);

-- Table for Guests joining Shared Experiences
CREATE TABLE SEGuests (
    SEId INT NOT NULL,
    GId INT NOT NULL,
    PRIMARY KEY (SEId, GId),
    FOREIGN KEY (SEId) REFERENCES SE(SEId),
    FOREIGN KEY (GId) REFERENCES Guests(GId)
);
