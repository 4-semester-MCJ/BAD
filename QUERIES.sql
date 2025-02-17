USE experienceSharedDb;

-- 1. Get the data collected for each experience provider.
SELECT Name, BPA, PhoneNum, CVR FROM Providers;

-- 2. List experiences
SELECT Name, Description, Price FROM Experiences;

-- 3. Shared experiences
SELECT Name, Date FROM SE ORDER BY Date DESC;

-- 4. Guest for shared experience
SELECT  G.Name
FROM SEGuests SEG
JOIN Guests G ON SEG.GId = G.GId
ORDER BY SEG.SEId;

-- 5. Get experiences in shared experience
SELECT SE.Name AS SharedExperience, E.Name AS Experience 
FROM SEDets SED
JOIN SE ON SED.SEId = SE.SEId
JOIN Experiences E ON SED.EId = E.EId;

-- 6. Guests registered for one experience in a shared experience
SELECT G.Name AS GuestName, SE.Name AS SharedExperience
FROM SEGuests SEG
JOIN SE ON SEG.SEId = SE.SEId
JOIN Guests G ON SEG.GId = G.GId
WHERE SE.Name = 'Parallel Universe Trip';


-- 7. Min, average, and max for experience
SELECT MIN(Price) AS MinPrice, AVG(Price) AS AvgPrice, MAX(Price) AS MaxPrice FROM Experiences;

-- 8. Get the number of guests and sum of sales for each experience available in the system.
SELECT E.Name AS Experience, COUNT(SEG.GId) AS NumberOfGuests, SUM(E.Price) AS TotalSales
FROM Experiences E
LEFT JOIN SEDets SED ON E.EId = SED.EId
LEFT JOIN SEGuests SEG ON SED.SEId = SEG.SEId
GROUP BY E.Name;

-- 9. Custom query: Find public shared experiences with more than one guest.
SELECT SE.Name, COUNT(SEG.GId) AS GuestCount
FROM SE
JOIN SEGuests SEG ON SE.SEId = SEG.SEId
GROUP BY SE.Name
HAVING COUNT(SEG.GId) > 1;