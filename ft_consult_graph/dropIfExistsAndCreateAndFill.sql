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
('Самокат', 1500.00),--1
('Амортизатор', 300.00),--2
('Рама', 1800.00),--3
('Подшипник', 200.00),--4
('Рулевая стойка', 1400.00),--5
('Руль', 500.00),--6
('Колесо', 500.00),--7
('Тормоз', 50.00),--8
('Тросс', 150.00),--9
('Диск',500.00),--10
('Крыло',300.00),--11
('Втулка', 100.00),--12
('Болт М2', 30.00),--13
('Гайка М2', 30.00),--14
('Шпилька M2', 50.00),--15
('Гайка T4', 10.00)--16

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