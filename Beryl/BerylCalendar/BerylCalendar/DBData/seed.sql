-- seed script

USE [BerylDB];

INSERT INTO [Type] ([Name]) VALUES
    ('Shopping'),
    ('Visit'),
    ('Meal'),
    ('Activity');

INSERT INTO [Account] ([Username]) VALUES
    ('test1'),
    ('user2'),
    ('admin3');

INSERT INTO [Event] ([AccountID], [TypeID], [Title], [StartDateTime], [EndDateTime], [Location], [Details]) VALUES 
    (1, 4, 'Tina`s Outside Baby Shower', '2021-03-10 12:30:00.0', '2021-03-10 03:00:00.0', 'Tina`s house', 'We still need a gift'),
    (3, 3, 'Gym with Tim', '2021-05-15 14:00:00.0', '2021-05-15 17:00:00.0', 'Health & Wellness Center', 'Remember swim trunks'),
    (2, 1, 'Grocery Run', '2021-02-25 10:45:00.0', '2021-02-25 14:00:00.0', 'Waremart', 'Eggs');
