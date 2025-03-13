USE experienceSharedDb;

INSERT INTO Providers (Name, BPA, PhoneNum, CVR) VALUES
('Area 51 B&B', '51 Classified Rd, Nowhereland', '555-UFOZ', 'DKALIEN666'),
('The Time Travelers Agency', '1.21 Gigawatt St, Past & Future', '555-WE-WERE', 'DK88888888');

INSERT INTO Guests (Name, Age, PhoneNum) VALUES
('Florida Man', 37, '555-GATOR'),
('Elon Dust', 52, '555-SPACEX'),
('Captain Obvious', 69, '555-OBVIOUS'),
('The Loch Ness Monster', 1500, '555-NEVERSEEN');

INSERT INTO Experiences (Name, Description, ProvId, Price) VALUES
('Sleepover at Area 51', 'Spend a night in the desert. If you disappear, we are nowhere near', 1, 300.00),
('Time Travel Weekend', 'Go back to last Friday to fix your mistakes.', 2, 5000.00),
('Ghost Hunting Bootcamp', 'Learn to communicate with the beyond. Refunds are ghostly figures only.', 1, 150.00),
('Jetpack Racing', 'Strap in and take off. Legal waivers required.', 2, 999.99);

INSERT INTO SE (Name, Date) VALUES
('Parallel Universe Trip', '2025-03-01'), -- Time doesn't exist here.
('Flat Earth Cruise', '2025-04-10'); -- Falls off the edge immediately.

INSERT INTO SEDets (SEId, EId) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4);

INSERT INTO SEGuests (SEId, GId) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4); 
