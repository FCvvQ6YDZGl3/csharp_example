ALTER TABLE Links
DROP CONSTRAINT FK_Links_IzdelUp
ALTER TABLE Links
DROP CONSTRAINT FK_Links_Izdel


DROP TABLE IF EXISTS Izdel
GO
CREATE TABLE Izdel
(
	Id BIGINT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) UNIQUE,
	Price DECIMAL(20, 2)
)

DROP TABLE IF EXISTS Links
GO
CREATE TABLE Links
(
	IzdelUp BIGINT,
	Izdel BIGINT,
	kol INT,
	CONSTRAINT FK_Links_IzdelUp FOREIGN KEY([IzdelUp])
	REFERENCES [dbo].Izdel(Id),
	CONSTRAINT FK_Links_Izdel FOREIGN KEY([Izdel])
	REFERENCES [dbo].Izdel(Id)
)
GO


INSERT INTO Izdel VALUES
('�������', 1500.00),--1
('�����������', 300.00),--2
('����', 1800.00),--3
('���������', 200.00),--4
('������� ������', 1400.00),--5
('����', 500.00),--6
('������', 500.00),--7
('������', 50.00),--8
('�����', 150.00),--9
('����',500.00),--10
('�����',300.00),--11
('������', 100.00),--12
('���� �2', 30.00),--13
('����� �2', 30.00),--14
('������� M2', 50.00),--15
('����� T4', 10.00)--16

INSERT INTO Links VALUES
(1,13,4),
(1,14,3),
(1,15,1),
(1,16,2),
(8,9,1),
(8,10,1),
(8,13,5),
(8,14,5),
(3,6,1),
(6,5,1),
(5,4,3),
(1,6,1),
(5,2,1),
(7,4,2),
(1,8,3),
(1,3,1),
(1,7,2),
(7,12,1),
(1,11,1)