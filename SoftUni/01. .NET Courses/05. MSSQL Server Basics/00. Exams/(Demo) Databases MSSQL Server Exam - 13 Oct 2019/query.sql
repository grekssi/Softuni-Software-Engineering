use BitBucket
go


--problem 1
CREATE TABLE Users(
    Id int primary key identity,
    Username nvarchar(30) not null,
    Password nvarchar(30) not null,
    Email nvarchar(50) not null
)

CREATE TABLE Repositories(
    Id int primary key identity not null,
    Name nvarchar(50) not null
)

CREATE TABLE RepositoriesContributors(
    RepositoryId int not null foreign key references Repositories(Id),
    ContributorId int not null foreign key references Users(Id),
    CONSTRAINT PK_Name primary key (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
    Id int primary key identity not null,
    Title nvarchar(255) not null,
    IssueStatus nvarchar(6) not null,
    RepositoryId int not null foreign key references Repositories(Id),
    AssigneeId int not null foreign key references Users(Id)
)

CREATE TABLE Commits(
    Id int primary key identity ,
    Message nvarchar(255) not null,
    IssueId int foreign key references Issues(Id),
    RepositoryId int not null foreign key references Repositories(Id) ,
    ContributorId int not null foreign key references Users(Id)
)

CREATE TABLE Files(
    Id int primary key identity not null,
    Name nvarchar(100) not null,
    Size DECIMAL(15, 2) not null,
    ParentId int foreign key references Files(Id),
    CommitId int not null foreign key references Commits(Id)
)


--problem2
INSERT INTO Files(Name, Size, ParentId, CommitId)
VALUES   ('Trade.idk', 2598.0, 1, 1),
    ('menu.net', 9238.31, 2, 2),
    ('Administrate.soshy', 1246.93, 3, 3),
    ('Controller.php', 7353.15, 4, 4),
    ('Find.java', 9957.86, 5, 5),
    ('Controller.json', 14034.87, 3, 6),
    ('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--problem 3
UPDATE Issues
SET IssueStatus = 'Closed'
WHERE AssigneeId = 6

--problem 4
DELETE TOP(1) FROM RepositoriesContributors
WHERE RepositoriesContributors.RepositoryId = (SELECT Id FROM Repositories where Name = 'Softuni-Teamwork')
DELETE TOP(1) FROM Issues
WHERE Issues.RepositoryId = (SELECT Id FROM Repositories where Name = 'Softuni-Teamwork')

--problem 4
SELECT Id, Message, RepositoryId, ContributorId FROM Commits order by Id, Message, RepositoryId, ContributorId

--problem5
SELECT Id, Name, Size FROM Files WHERE Size > 1000 AND CHARINDEX('html',Name) > 0
order by Size desc, id asc, Name asc

--problem 6
SELECT I.Id, u.Username + ' : ' + I.Title FROM Users u JOIN Issues I on u.Id = I.AssigneeId
ORDER BY I.id desc, I.AssigneeId asc

--problem 7
SELECT parent.Id, parent.Name, CONCAT(parent.Size, 'KB') as Size FROM Files main RIGHT JOIN Files parent on parent.Id = main.ParentId
WHERE main.Id IS NULL
order by Id, Name, Size

--problem 8
SELECT TOP(5) r.Id, r.Name, COUNT(C.ContributorId) FROM Repositories r
    JOIN RepositoriesContributors RC on r.Id = RC.RepositoryId
    JOIN Commits C on r.Id = C.RepositoryId
GROUP BY c.RepositoryId, r.Id, r.Name
order by COUNT(c.ContributorId) desc, r.Id asc, r.Name asc

--problem 9
SELECT Username, AVG(Size) FROM Users
    JOIN Commits C on Users.Id = C.ContributorId
    JOIN Files F on C.Id = F.CommitId
GROUP BY Users.Username
ORDER BY AVG(Size) desc, Username asc

--problem 10
CREATE FUNCTION udf_UserTotalCommits(@username varchar(20))
RETURNS int
BEGIN
    return(SELECT COUNT(c.Id) FROM Users join Commits C on Users.Id = C.ContributorId WHERE Username = @username)
end
--problem 11
CREATE PROC usp_FindByExtension(@extension varchar(15))
AS
    SELECT Id, Name, CONCAT(Size, 'KB') FROM Files WHERE Name LIKE CONCAT('%', @extension)
    order by Id, Name, Size

