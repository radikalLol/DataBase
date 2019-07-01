--2. ������� ������� � ���� ������.
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



--�������� �������
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
('100 ��','5'),
('300-450 ��','4'),
('550-600 ��','3'),
('1000-2500 ��','2'),
('3000-5000 ��','1');
GO

INSERT ReliabilityOfDelivery
(MissionCompleted,MissionIncompleted)
VALUES
('5','2');
GO

INSERT TimeOFDelivery
(TimeABC,Points)
VALUES
('�� 3-4 ����','5'),
('�� 4-7 ���� ','4'),
('�� 7-10 ����','3'),
('�� 10-14 ����','2'),
('�� 14 � ������ ���� ��������','1');
GO

INSERT ShipperS
(FName,[Address],Phone,INN,CheckingAccount)
VALUES
('������� ����������', '������� 21�,137, ����� �����','(902)3544874','500100732259','12345678901234567890'),
('���� ���������', '��������,15, ����� ������','(902)3584874','500200832259','12385678903234767890'),
('���� �����', '������� �������, ����� ������','(908)3554821','500105732259','12348678903434567890'),
('��������� ��������� �������', '������ 23, ����� �����','(902)3544489','500109732269','12345678901233567791'),
('������ ������������ ������', '���������� 20, ����� ��������','(962)3144814','500100883259','12345678901234567890');
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
('������� ����������','3000','������','50 ��','���������','3 ���'),
('���� ���������','7000','�������','305��','���������','6 ����'),
('���� �����','2000','�������','75 ��','���������','3 ���'),
('��������� ��������� �������','15000','�������','1025 ��','�� ���������','11 ����'),
('������ ������������ ������','23000','������','575 ��','���������','9 ����');
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