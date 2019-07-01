--2. Создаем таблицы в Базе Данных.
USE ShipperSS
CREATE TABLE PriceList
(ID int NOT NULL,
Price varchar(250) NULL,
Points varchar(250) NULL
)
GO

CREATE TABLE Quality
(ID int NOT NULL,
HighQuality varchar(250) NULL,
MediumQuality varchar(250) NULL,
LowQuality varchar(250) NULL
)
GO

CREATE TABLE LocationOFSuppliers
(ID int NOT NULL,
LocationABC varchar(250) NULL,
Points varchar(250) NULL
)
GO

CREATE TABLE ReliabilityOfDelivery
(ID int NOT NULL,
MissionCompleted varchar(250) NULL,
MissionIncompleted varchar(250) NULL
)
GO

CREATE TABLE TimeOFDelivery
(ID int NOT NULL,
TimeABC varchar(250) NULL,
Points varchar(250) NULL
)
GO

CREATE TABLE ShipperS
(ID int NOT NULL,
FName varchar(250) NULL,
[Address] varchar(250) NULL,
Phone varchar(250) NULL,
INN varchar(250) NULL,
CheckingAccount varchar(250) NULL
)
GO

CREATE TABLE ShippersPoints
(ID int NOT NULL,
SipperS varchar(250) NULL,
PriceList varchar(250) NULL,
Quality varchar(250) NULL,
LocationOFSuppliers varchar(250) NULL,
ReliabilityOfDelivery varchar(250) NULL,
TimeOFDelivery varchar(250) NULL
)
GO

CREATE TABLE CriteriasOfChoice
(ID int NOT NULL,
Criterias1 varchar(250) NULL,
Criterias2 varchar(250) NULL,
Criterias3 varchar(250) NULL
)
GO

USE ShipperSS
CREATE TABLE ReferenceData
(ID int NOT NULL,
CompanyName varchar(250) NULL,
PriceList varchar(250) NULL,
Quality varchar(250) NULL,
LocationOfSuppliers varchar(250) NULL,
ReliabilityOfDelivery varchar(250)NULL,
TimeOfDelivery varchar(250) NULL
)
GO

ALTER TABLE ShipperS
ADD
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO



--Удаление записей
DELETE FROM dbo.PriceList
DELETE FROM dbo.Quality
DELETE FROM dbo.LocationOFSuppliers
DELETE FROM dbo.ReliabilityOfDelivery
DELETE FROM dbo.TimeOFDelivery
DELETE FROM dbo.ShipperS
DELETE FROM dbo.ShippersPoints
DELETE FROM dbo.CriteriasOfChoice
DELETE FROM dbo.ReferenceData

INSERT PriceList
(Price,Points)
VALUES
('1000-5000','5'),
('1000-10000','4'),
('2000-10000','3'),
('3000-15000','2'),
('3000-25000','1');
GO

INSERT Quality
(HighQuality,MediumQuality,LowQuality)
VALUES
('1','3','5');
GO

INSERT LocationOFSuppliers
(LocationABC,Points)
VALUES
('100 км','5'),
('300-450 км','4'),
('550-600 км','3'),
('1000-2500 км','2'),
('3000-5000 км','1');
GO

INSERT ReliabilityOfDelivery
(MissionCompleted,MissionIncompleted)
VALUES
('5','2');
GO

INSERT TimeOFDelivery
(TimeABC,Points)
VALUES
('от 3-4 дней','5'),
('от 4-7 дней ','4'),
('от 7-10 дней','3'),
('от 10-14 дней','2'),
('от 14 и больше дней доставки','1');
GO

INSERT ShipperS
(FName,[Address],Phone,INN,CheckingAccount)
VALUES
('Виталий Прокопенко', 'Руденко 21а,137, город Пенза','(902)3544874','500100732259','12345678901234567890'),
('Кира Виталенко', 'Забелина,15, город Москва','(902)3584874','500200832259','12385678903234767890'),
('Марк Серов', 'Большая Ордынка, город Москва','(908)3554821','500105732259','12348678903434567890'),
('Елизавета Андреевна Сочкова', 'Артема 23, город Львов','(902)3544489','500109732269','12345678901233567791'),
('Кирилл Владимирович Ситков', 'Контрактна 20, город Николаев','(962)3144814','500100883259','12345678901234567890');
GO

INSERT ShippersPoints
(SipperS,PriceList,Quality,LocationOFSuppliers,ReliabilityOfDelivery,TimeOFDelivery)
VALUES
('','','','','',''),
('','','','','',''),
('','','','','','');
GO

INSERT CriteriasOfChoice
(Criterias1,Criterias2,Criterias3)
VALUES
('','',''),
('','',''),
('','',''),
('','','');
GO

INSERT ReferenceData
(CompanyName,PriceList,Quality,LocationOfSuppliers,ReliabilityOfDelivery,TimeOfDelivery)
VALUES
('Виталий Прокопенко','3000','Низкое','50 км','Выполнено','3 дня'),
('Кира Виталенко','7000','Высокое','305км','Выполнено','6 дней'),
('Марк Серов','2000','Высокое','75 км','Выполнено','3 дня'),
('Елизавета Андреевна Сочкова','15000','Среднее','1025 км','Не выполнено','11 дней'),
('Кирилл Владимирович Ситков','23000','Низкое','575 км','Выполнено','9 дней');
GO

SELECT * FROM dbo.PriceList
SELECT * FROM dbo.Quality
SELECT * FROM dbo.LocationOFSuppliers
SELECT * FROM dbo.ReliabilityOfDelivery
SELECT * FROM dbo.TimeOFDelivery
SELECT * FROM dbo.ShipperS
SELECT * FROM dbo.ShippersPoints
SELECT * FROM dbo.CriteriasOfChoice
SELECT * FROM dbo.ReferenceData