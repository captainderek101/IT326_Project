
DROP TABLE IF EXISTS Quotes;
DROP TABLE IF EXISTS CurQuote;
DROP TABLE IF EXISTS Articles;

CREATE TABLE Articles (
	title VarChar(300),
	Url VarChar(300),
	time VarChar(100)
)

CREATE TABLE Quotes (
	id INT IDENTITY(1,1) PRIMARY KEY,
	text VarChar(100)
)
CREATE TABLE CurQuote (
	id INT,
	time VarChar(100)
)

INSERT INTO	Quotes (text) VALUES 
('You can do this!'),
('You are capable of amazing things. Keep pushing forward!'),
('Every challenge you face is an opportunity to grow. Keep going.'),
('Believe in yourself. You have everything you need to succeed.'),
('You are more than enough, just as you are.'),
('Small steps lead to big changes. Keep making progress.'),
('No matter how slow you go, you’re still lapping everyone on the couch.'),
('Every day is a new chance to start fresh. Take it!'),
('You are stronger than you think. Keep showing up.'),
('There is beauty in every moment. Look for it, and you''ll find it.'),
('Your efforts are worth it, even when the results aren’t immediate.'),
('Stay positive, work hard, and make it happen.'),
('Your uniqueness is your superpower. Never forget that!'),
('The best is yet to come. Keep your head up!'),
('You’re doing better than you think. Be proud of yourself.'),
('You are worthy of all the love, success, and happiness the world has to offer.'),
('Choose positivity and let it guide you through the day.'),
('No matter what happens today, you’ve got this!');
