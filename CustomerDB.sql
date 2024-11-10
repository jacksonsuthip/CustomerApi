CREATE DATABASE CustomerDB;
GO

USE CustomerDB;
GO

CREATE TABLE CustomerMaster (
    CustomerCode INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    MobileNo VARCHAR(15) NOT NULL,
    GeoLocation VARCHAR(50)
);
GO
INSERT INTO CustomerMaster (Name, Address, Email, MobileNo, GeoLocation) VALUES
('Lionel Messi', 'Avenida Messi 10, Rosario, Argentina', 'lionel.messi@football.com', '1234567890', '-32.9468,-60.6393'),
('Cristiano Ronaldo', 'CR7 House, Funchal, Madeira, Portugal', 'cristiano.ronaldo@football.com', '2345678901', '32.6519,-16.9076'),
('Neymar Jr.', 'Rua Ney 11, Mogi das Cruzes, Brazil', 'neymar.jr@football.com', '3456789012', '-23.1859,-46.8915'),
('Magnus Carlsen', 'Magnus’s Residence, Tonsberg, Norway', 'magnus.carlsen@chess.com', '4567890123', '59.2672,10.3495'),
('Viswanathan Anand', 'Chennai, India', 'viswanathan.anand@chess.com', '5678901234', '13.0827,80.2707'),
('Bobby Fischer', 'Brooklyn, New York, USA', 'bobby.fischer@chess.com', '6789012345', '40.6782,-73.9442'),
('Virat Kohli', 'Mumbai, Maharashtra, India', 'virat.kohli@cricket.com', '7890123456', '19.0760,72.8777'),
('Sachin Tendulkar', 'Mumbai, Maharashtra, India', 'sachin.tendulkar@cricket.com', '8901234567', '19.0760,72.8777'),
('Ricky Ponting', 'Hobart, Tasmania, Australia', 'ricky.ponting@cricket.com', '9012345678', '-42.8794,147.3238'),
('Ben Stokes', 'Bristol, England', 'ben.stokes@cricket.com', '0123456789', '51.4545,-2.5879');
GO
